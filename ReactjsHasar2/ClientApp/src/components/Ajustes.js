import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Arqueo.css';

export class Ajustes extends Component {
    displayName = Ajustes.name

    constructor(props) {
        super(props);
        this.state = {
            numSuc: 0,
            numCaja: 0,
            mensaje:'',
        };

        this.TraerDatos();

    }


    async TraerDatos() {
        const url = "http://localhost:61063/api/Ajustes";
        const response = await fetch(url);
        var data = await response.json();

        try {
            document.getElementById('nSucursal').value = data[0].numSucursal;
            document.getElementById('numCaja').value = data[0].numeroCaja;
        } catch (err) {
            this.setState({ mensaje:'No hay ajustes definidos' });
        }
        this.setState({ numSuc: data.numeroCaja, numCaja: data.numSucursal });
    }

    GuardarCambios() {
        var numSuc= document.getElementById('nSucursal').value;
        var numCaja = document.getElementById('numCaja').value;

        fetch('http://localhost:61063/api/Ajustes', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                numeroCaja: numCaja,
                numSucursal: numSuc,
            })
        }).then(function (response) {
            if (response.ok) {
                alert('Ajustes actualizados');
            }
            else {
                alert('Error no se pudo actualizar');
            }
            });

    }
    

    render() {
        return (
            <div className="darSeparacion">
                <h1>Ajustes</h1>
                <p> {this.state.mensaje} </p>
                <table>
                    <tr>
                        <td>Numero de sucrusal</td>
                        <td> <input id="nSucursal" type="number"/> </td>
                    </tr>
                    <tr>
                        <td>Numero de caja</td>
                        <td> <input id="numCaja" type="number" /> </td>
                    </tr>
                    <tr>
                        <td> <button onClick={() => { this.GuardarCambios() }} className="btn btn-success"> Guardar cambios </button> </td>
                        <td>  </td>
                    </tr>

                </table>
                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
