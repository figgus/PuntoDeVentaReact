import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Operadores.css';


export class AgregarOperador extends Component {
    //borrar si no se usa
    displayName = AgregarOperador.name

    constructor() {
        super();
        this.state = { tipoDocumento: [], NivelSeguridad: [] };
        this.TraerTiposDocumentos();
        this.TraerNivelSeguridad();
    }

    async TraerTiposDocumentos() {
        const url = "http://localhost:61063/api/TipoDocumentoes";
        const response = await fetch(url);
        var data = await response.json();
        //console.log(data);

        this.setState({ tipoDocumento: data });
    }

    async TraerNivelSeguridad() {
        const url = "http://localhost:61063/api/NivelSeguridads";
        const response = await fetch(url);
        var data = await response.json();
        //console.log(data);

        this.setState({ NivelSeguridad: data });
    }

    

    render() {
        return (
            <div>
                <div className="darSeparacion">
                    <h1>Operadores</h1>
                    <table>
                        <tr>
                            <td>Codigo Operador</td>
                            <td><input type="number" /></td>
                        </tr>
                        <tr>
                            <td>Primer Nombre</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Segundo Nombre</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Apellido paterno</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Apellido materno</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Direccion</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Localidad</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Codigo postal</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Provincia</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Pais</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Telefonos</td>
                            <td><input type="text" /></td>
                        </tr>
                        <tr>
                            <td>Documento</td>
                            <td> <select>
                                {this.state.tipoDocumento.map((item, index) => (
                                    <option selected> {item.descDoc} </option>

                                ))
                                }
                            </select> </td>
                            <td><input type="text" placeholder="1111111-1" /></td>
                        </tr>
                        <tr>
                            <td>Nivel Seguridad</td>
                            <td> <select>
                                {this.state.NivelSeguridad.map((item, index) => (
                                    <option selected> {item.nivelPermiso + ' - ' + item.descripcion} </option>

                                ))
                                }
                            </select> </td>
                        </tr>
                        <tr>
                            <td>Contraseña</td>
                            <td><input type="password" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>></td>
                        </tr>
                    </table>
                    <Link to="/menu"><button className="btn btn-secondary">Cerrar</button></Link>
                </div>
            </div>
        );
    }
}
