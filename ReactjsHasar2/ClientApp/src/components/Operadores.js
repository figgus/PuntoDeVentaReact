import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Operadores.css';
import { AgregarOperador } from './AgregarOperador';
import { Route } from 'react-router';


export class Operadores extends Component {
    displayName = Operadores.name

    constructor() {
        super();
        this.state = { tipoDocumento: [], NivelSeguridad: [], operadores: [] };
        this.TraerOperadores();
    }

    async TraerOperadores() {
        const url = "http://localhost:61063/api/TipoDocumentoes";
        const response = await fetch(url);
        var data = await response.json();

        console.log(data);

        this.setState({ tipoDocumento: data });
    }

    

    render() {
        return (
            <div>
                <table>
                    <tr>
                        <thead></thead>
                        <tbody></tbody>
                        <Route path="/Operadores/Agregar" component={AgregarOperador} />
                    </tr>
                </table>
                <Link to="/Operadores/Agregar"><button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
