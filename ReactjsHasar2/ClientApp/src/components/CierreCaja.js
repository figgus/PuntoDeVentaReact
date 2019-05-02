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
    
    getFecha() {
        return new Date().getDate();
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
                        <td className="tablaOrden">{this.state.fecha} </td>
                    </tr>
                    <tr>
                        <td className="tablaOrden"></td>
                        <td className="tablaOrden"></td>
                        <td className="tablaOrden">{this.state.hora} </td>
                    </tr>
                    <tr>
                        <td className="tablaOrden"> <button className="btn btn-secondary">Cierre Z</button> </td>
                        <td className="tablaOrden"></td>
                        <td className="tablaOrden"><Link to="/menu"><button className="btn btn-secondary">Cerrar</button></Link> </td>
                    </tr>
                </table>
                
            </div>
        );
    }
}
