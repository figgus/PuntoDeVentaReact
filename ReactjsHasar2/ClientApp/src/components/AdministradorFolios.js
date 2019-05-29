import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class AdministradorFolios extends Component {
    displayName = AdministradorFolios.name

    constructor() {
        super();
        this.state = {
            folios:[],
            totales:0,
            restantes: 0,
            rangoTotalesMin: 0,
            rangoTotalesMax: 0,
            rangoDispMin: 0,
            rangoDispMax: 0,
            mensaje:'',

        }

        this.TraerDatos();
    }

    TraerDatos() {
        try {
            this.TraerRestantes();
            this.TraerTotales();
            this.TraerRangoTotalMin();
            this.TraerRangoTotalMax();
            this.TraerRangoDisponibleMin();
            this.TraerRangoDisponibleMax();
        } catch (err) {
            this.setState({ mensaje:'El servicio de administracion de folios no esta disponible' });
        }
    }

    async TraerTotales() {
        try {
            const url = "http://localhost:59017/OperacionesFolios/getTotal";
            const response = await fetch(url);
            const data = await response.json();

            this.setState({ totales: data.numeroFolios });
        } catch (err) {
            this.setState({ mensaje: 'El servicio de administracion de folios no esta disponible' });
        }
    }

    async TraerRestantes() {
        try {
            const url = "http://localhost:59017/OperacionesFolios/getFoliosDisponibles";
            const response = await fetch(url);
            const data = await response.json();
            this.setState({ restantes: data.foliosDisponibles });
        } catch (err) {
            this.setState({ mensaje: 'El servicio de administracion de folios no esta disponible' });
        }
    }

    async TraerRangoTotalMin() {
        try {
            const url = "http://localhost:59017/OperacionesFolios/getFolioMin";
            const response = await fetch(url);
            const data = await response.json();
            this.setState({ rangoTotalesMin: data.primerFolio });
        } catch (err) {
            this.setState({ mensaje: 'El servicio de administracion de folios no esta disponible' });
        }
    }

    async TraerRangoTotalMax() {
        try {
            const url = "http://localhost:59017/OperacionesFolios/getFolioMax";
            const response = await fetch(url);
            const data = await response.json();
            this.setState({ rangoTotalesMax: data.ultimoFolio });
        } catch (err) {
            this.setState({ mensaje: 'El servicio de administracion de folios no esta disponible' });
        }
    }


    async TraerRangoDisponibleMax() {
        try {
            const url = "http://localhost:59017/OperacionesFolios/getMaxDisp";
            const response = await fetch(url);
            const data = await response.json();
            this.setState({ rangoDispMax: data.maxFolioDisp });
        } catch (err) {
            this.setState({ mensaje: 'El servicio de administracion de folios no esta disponible' });
        }
    }

    async TraerRangoDisponibleMin() {
        try {
            const url = "http://localhost:59017/OperacionesFolios/getMinDisp";
            const response = await fetch(url);
            const data = await response.json();
            this.setState({ rangoDispMin: data.minFolioDisp });
        } catch (err) {
            this.setState({ mensaje: 'El servicio de administracion de folios no esta disponible' });
        }
    }

    EstiloAlerta = {
        'color': 'red',
        'font-weight':'500'
    }

   

    render() {
        return (
            <div>
                <h1> Panel de administracion del SAF</h1>
                <p style={this.EstiloAlerta}> {this.state.mensaje} </p>
                <p>Folios totales {this.state.totales}</p>
                <p>Folios restantes: {this.state.restantes}</p>
                <p>Rango de Folios totales :</p>
                <p>Desde {this.state.rangoTotalesMin} hasta {this.state.rangoTotalesMax}</p>
                <p>Rango de Folios disponibles: desde el {this.state.rangoDispMin} hasta {this.state.rangoDispMax}</p>

                <div>
                    Ingresar nuevo set de folios
                </div>
                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
