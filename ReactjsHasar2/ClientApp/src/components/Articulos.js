import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Articulos extends Component {
    displayName = Articulos.name
    constructor() {
        super();
        this.state={
            secciones: [],
            articulos: [],

        };
        this.TraerSecciones();
        this.TraerArticulos();
    }

    async TraerSecciones() { //categorias
        const url = "http://localhost:61063/api/SubfuncionsCategorias";
        const response = await fetch(url);
        var data = await response.json();
        this.setState({ secciones: data });
    }

    async TraerArticulos() { 
        const url = "http://localhost:61063/api/plu";
        const response = await fetch(url);
        var data = await response.json();
        console.log(data);
        this.setState({ articulos: data });
    }

    //AgregarArticulo() {
    //    var codigoInterno = document.getElementById('nroLegajo').value;
    //    var stock= document.getElementById('apellido').value;
    //    var codigoBarra= document.getElementById('apellidoMaterno').value;
    //    var codigoSProveedor= document.getElementById('clave').value;
    //    var codigoDoc = document.getElementById('codigoDoc').value;
    //    var cantidadReposicion = document.getElementById('codigoOperador').value;
    //    var descripcion = document.getElementById('codigoPostal').value;

    //    var seccion = document.getElementById('direccion').value;
    //    var localidad = document.getElementById('localidad').value;
    //    var direccion = document.getElementById('direccion').value;
    //    var localidad = document.getElementById('localidad').value;
    //    var direccion = document.getElementById('direccion').value;
    //    var localidad = document.getElementById('localidad').value;
    //    var direccion = document.getElementById('direccion').value;
    //    var direccion = document.getElementById('direccion').value;
    //    var localidad = document.getElementById('localidad').value;

    //    var localidad = document.getElementById('localidad').value;

    //    fetch('http://localhost:61063/api/plu/', {
    //        method: 'POST',
    //        headers: {
    //            'Content-Type': 'application/json',
    //        },
    //        body: JSON.stringify({
    //            nroLegajo: nroLegajo,
    //            telefono: telefono,

    //        })
    //    }).then(function (response) {
    //        if (response.ok) {
    //            alert('Usuario creado con exito');
    //        }
    //        else {
    //            alert('Algo salio mal');
    //        }
    //    });
    //}


    aDerecha = {
        float: 'right'
    }
    aIzquierda = {
        float: 'right'
    }
    render() {
        return (
            <div>
                <div className="darSeparacion">
                    <div className="darSeparacion">
                        
                        <h1>Articulos</h1>
                        <table>
                              <tr>
                                <td>Codigo Interno</td>
                                <td><input  type="number" />  <select></select></td>
                                     <td>Stock</td>
                                <td><input className="form-control" type="number" />
                                </td>
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
                        </div>
                        <div className="darSeparacion" style={this.aDerecha}>
                            <h3> Precio </h3>
                        <table>
                                <tr>

                                    <td>Recargo/Descuento </td>
                                    <td><input className="form-control" type="text" /></td>
                                </tr>
                                <tr>

                                    <td> </td>
                                    <td>Costo <input type="text" /></td>
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
                        </div>
                        <div style={this.aIzquierda} className="darSeparacion">
                        Envase
                            <table>
                                <tr>
                                    <td>
                                        <input type="radio" name="gender" value="male"/> Tiene envase
                                        <input type="radio" name="gender" value="male" /> Es envase
                                    </td>    
                                </tr>
                            </table>
                        </div>
                        <div className="darSeparacion">
                            Seccion
                            <table>
                                <tr>
                                    <td>
                                        Seccion
                                    </td>
                                <td> <select className="form-control">
                                    {

                                        this.state.secciones.map((item, index) => (
                                            <option key={index}> {item.descSubFn} </option>
                                        ))
                                    }
                                </select></td>
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
                        </div>

                        <div className="darSeparacion">
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
                        </div>
                    <button className="btn btn-success">Agregar</button>
                    <button className="btn btn-danger">Borrar</button>
                    <button className="btn btn-primary">Modificar</button>
                </div>

                <Link to="/menu"><button className="btn btn-secondary">Cerrar</button></Link>

            </div>
        );
    }
}
