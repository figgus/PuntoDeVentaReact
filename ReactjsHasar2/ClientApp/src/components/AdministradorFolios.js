import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { stat } from 'fs';

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

        }

        this.TraerDatos();
    }

    TraerDatos() {
        this.TraerRestantes();
        this.TraerTotales();
        this.TraerRangoTotalMin();
        this.TraerRangoTotalMax();
        this.TraerRangoDisponibleMin();
        this.TraerRangoDisponibleMax();
    }

    async TraerTotales() {
        const url = "http://localhost:49929/api/FoliosP";
        const response = await fetch(url);
        const data = await response.json();
        
        this.setState({ totales: data.length });
    }

    async TraerRestantes() {
        const url = "http://localhost:49929/getFoliosDisponibles";
        const response = await fetch(url);
        const data = await response.json();
        this.setState({ restantes: data.foliosDisponibles });
    }

    async TraerRangoTotalMin() {
        const url = "http://localhost:49929/getFolioMin";
        const response = await fetch(url);
        const data = await response.json();
        this.setState({ rangoTotalesMin: data.primerFolio });
        //console.log(data.primerFolio);
    }

    async TraerRangoTotalMax() {
        const url = "http://localhost:49929/getFolioMax";
        const response = await fetch(url);
        const data = await response.json();
        this.setState({ rangoTotalesMax: data.ultimoFolio });
        //console.log(data.ultimoFolio);
    }


    async TraerRangoDisponibleMax() {
        const url = "http://localhost:49929/getMaxDisp";
        const response = await fetch(url);
        const data = await response.json();
        this.setState({  rangoDispMax: data.maxFolioDisp });
    }

    async TraerRangoDisponibleMin() {
        const url = "http://localhost:49929/getMinDisp";
        const response = await fetch(url);
        const data = await response.json();
        this.setState({ rangoDispMin: data.minFolioDisp });
    }

    //async TraerFolios() {
    //    const url = "http://localhost:49929/api/FoliosLocals";
    //    const response = await fetch(url);
    //    const data = await response.json();
    //    console.log(data);
    //    this.setState({ folios: data });
    //}

    render() {
        return (
            <div>
                <h1> Panel de administracion del SAF</h1>
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
