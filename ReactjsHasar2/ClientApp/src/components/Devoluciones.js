import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import swal from 'sweetalert';
import { GetUrlLocal } from './Globales/VariblesGlobales';


export class Devoluciones extends Component {
    displayName = Devoluciones.name

    constructor() {
        super();
        this.state = {
            tipoDteUsado:60,
        };
        
        

    }


    async EnviarNotaDeCredito() {
        try {
            const numFolio = document.getElementById('numFolio').value;
            const tipoDte = this.state.tipoDteUsado;
            const url = GetUrlLocal() + "/enviarDTE";
            console.log(url);
            var respuesta = await fetch(url, {//dteController
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ detalles: null, numFolio: numFolio, tipoDocumento: tipoDte }),
            });
            if (!respuesta.ok)
                throw 'No fue posible conectarse a la API local';

            var data = await respuesta.json();
        } catch (err) {
            swal(err);
        }
        
        
    }


    render() {
        return (
            <div className="darSeparacion">
                <center>
                    <form className="form-inline">
                        <div className="form-group mb-2" id="encabezado">
                            <p>Ingrese el numero de folio de la venta
                            <input className="form-control form-control-sm" id="numFolio"></input>
                            </p>
                            <button type="button" onClick={() => { this.EnviarNotaDeCredito()}} class="btn btn-success">Anular venta</button>
                        </div>
                    </form>
                </center>
                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
