import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class CierreCaja extends Component {
    displayName = CierreCaja.name

    constructor() {
        super();
        this.state = {
            fecha: new Date().toLocaleDateString(),
            hora: new Date().toLocaleTimeString()
        };
    }

    componentDidMount() {
        this.FechaDefault();
        var campoHora = document.getElementById('hora');
        campoHora.value = this.state.hora;
    }

    CrearZeta() {
        fetch('http://localhost:61063/api/Zetas', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                NroPOS: 1,

            })
        });
        alert('Procesos completado con exito');
    }
    
    FechaDefault() {
        var date = new Date();

        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear(),
            hour = date.getHours(),
            min = date.getMinutes();

        month = (month < 10 ? "0" : "") + month;
        day = (day < 10 ? "0" : "") + day;
        hour = (hour < 10 ? "0" : "") + hour;
        min = (min < 10 ? "0" : "") + min;

        var today = year + "-" + month + "-" + day,
            displayTime = hour + ":" + min;

        document.getElementById('fecha').value = today;
    }

    render() {
        return (
            <div id="PorDepartamentos">
                <table className="tablaOrden">
                    <tr>
                        <h1>Cierre del dia de ventas</h1>
                    </tr>
                    <tr>
                        <td className="tablaOrden">La fecha y la hora se transmiten automaticamente luego de realizar la Z confirme que esta seguro</td>
                        <td className="tablaOrden">Numero de Z</td>
                        <td className="tablaOrden"><input readOnly defaultValue={this.state.fecha} id="fecha" type="date" /> </td>
                    </tr>
                    <tr>
                        <td className="tablaOrden"></td>
                        <td className="tablaOrden"></td>
                        <td className="tablaOrden"> <input readOnly type="text" id="hora" /> </td>
                    </tr>
                    <tr>
                        <td className="tablaOrden"> <button onClick={() => { if (window.confirm('¿Esta seguro que quiere hacer el cierre de caja?')) { this.CrearZeta() }; }} className="btn btn-secondary">Cierre Z</button> </td>
                        <td className="tablaOrden"></td>
                        <td className="tablaOrden"><Link to="/menu"><button className="btn btn-secondary">Cerrar</button></Link> </td>
                    </tr>
                </table>
                
            </div>
        );
    }
}
