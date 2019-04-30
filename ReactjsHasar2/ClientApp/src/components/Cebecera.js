import React, { Component } from 'react';

export class Cabecera extends Component {
    displayName = Cabecera.name

    constructor() {
        super();
        
    }

    removerAtt() {
        document.getElementById('tcabecera').removeAttribute('style');
    }

    render() {
        return (
            <div>
                <table id="tcabecera">
                    <tr>
                        <td>  <p> Operador 9999 -</p></td>
                        <td>Administrador </td>
                    </tr>
                    <tr>
                        <td><p>Cliente: Consumidor final </p> </td>
                        <td>  <button className="btn btn-secondary">Ver clientes</button></td>
                    </tr>
                    <tr>
                        <td> <p>Tipo documento </p> </td>
                        <td> <select>
                            <option>Boleta fiscal</option>
                        </select> </td>
                    </tr>
                </table>
                {this.removerAtt()}
            </div>
        );
    }
}
