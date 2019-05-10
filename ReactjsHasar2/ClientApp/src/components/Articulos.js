import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Articulos extends Component {
    displayName = Articulos.name




    aDerecha = {
        float: 'right'
    }
    render() {
        return (
            <div>
                <div className="darSeparacion">
                    <h1>Articulos</h1>
                    <table>
                        <tr>
                            <td>Codigo Interno</td>
                            <td><input className="form-control" type="number" /></td>
                            <td>Stock</td>
                            <td><input className="form-control" type="number" /></td>
                        </tr>
                        <tr>
                            <td>Codigo de barras</td>
                            <td><input className="form-control" type="text" /></td>
                            <td>Stock en combos</td>
                            <td><input className="form-control" type="number" /></td>
                        </tr>
                        <tr>
                            <td>Codigo S/Proveedor</td>
                            <td><input className="form-control" type="text" /></td>
                            <td> Cantidad reposicion</td>
                            <td><input className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Descripcion</td>
                            <td>
                                <textarea rows="4" cols="50">
                                    
                                </textarea>
                            </td>
                        </tr>
                       
                    </table>
                    Envase
                    <table>
                        <tr>
                            <td>
                                <input type="radio" name="gender" value="male"/> Tiene envase
                                <input type="radio" name="gender" value="male" /> Es envase
                            </td>    
                        </tr>
                    </table>
                    Seccion
                    <table>
                        <tr>
                            <td>
                                Seccion
                            </td>
                            <td> <select> <option>Fijo</option> </select></td>
                        </tr>
                        <tr>
                            <td>
                                Ultima actualizacion
                            </td>
                            <td> <select> <option>Fijo</option> </select></td>
                        </tr>
                        <tr>
                            <td>
                                Proveedor
                            </td>
                            <td> <select> <option>Fijo</option> </select></td>
                        </tr>
                    </table>


                    Precio
                    <table>
                        <tr>
                            
                            <td>Recargo/Descuento </td>
                            <td><input className="form-control" type="text" /></td>
                        </tr>
                        <tr>

                            <td> </td>
                            <td>Costo <input  type="text" /></td>
                        </tr>
                        <tr>

                            <td>Impuesto interno </td>
                            <td><input type="text" /></td>
                            <td> <select> <option>Porcentaje</option> </select>
                                <select> <option>Fijo</option> </select>
                            </td>
                        </tr>
                        <tr>
                            <td>Grupo impuestos </td>
                            <td><input className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Porcentaje bonificacion </td>
                            <td><input className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Porcentaje margen </td>
                            <td><input className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td><input type="checkbox" /> Precio en dolares </td>
                        </tr>

                        
                    </table>
                    Presentacion
                    <table>
                        <tr>
                            <td> Cantidad/Unidades </td>
                            <td> <input type="number" />  <select>  <option>Fijo</option></select> </td>
                        </tr>
                        <tr>
                            <td>Unidades x bulto</td>
                            <td> <input type="number" /> </td>
                        </tr>
                    </table>
                    <Link to="/menu"><button className="btn btn-secondary">Cerrar</button></Link>
                </div>

                

            </div>
        );
    }
}
