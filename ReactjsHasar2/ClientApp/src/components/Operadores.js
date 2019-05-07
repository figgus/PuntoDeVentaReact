import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Operadores.css';
import { AgregarOperador } from './AgregarOperador';


export class Operadores extends Component {
    displayName = AgregarOperador.name

    constructor() {
        super();
        this.state = {
            tipoDocumento: [],
            NivelSeguridad: [],
            operadores: [],
            AgregarOperador:true
        };
        this.TraerTiposDocumentos();
        this.TraerNivelSeguridad();
        this.TraerOperadores();
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

    async TraerOperadores() {
        const url = "http://localhost:61063/api/Operadors";
        const response = await fetch(url);
        var data = await response.json();
        console.log(data);

        this.setState({ operadores: data });
    }

     SeleccionarOperador() {
        var selbox = document.getElementById("codigoOperador");
        var idx = selbox.selectedIndex;
        var idOperador = selbox.options[idx].value;

         if (idOperador != 'Nuevo operador') {
             this.setState({ AgregarOperador: false });
             //console.log('agregar operador es false');
             idOperador = idOperador.substr(0, idOperador.indexOf('-'));
             var operador = this.state.operadores.find(obj => {
                 return obj.codigoOperador == idOperador;
             });
             document.getElementById('codigoOperadortxt').value = operador.codigoOperador;
             document.getElementById('nroLegajo').value = operador.nroLegajo;
             document.getElementById('apellido').value = operador.apellido;
             document.getElementById('apellidoMaterno').value = operador.apellidoMaterno;
             document.getElementById('clave').value = operador.clave;
             document.getElementById('codigoDoc').value = operador.codigoDoc;
             //document.getElementById('codigoOperador').value = operador.codigoOperador;
             document.getElementById('codigoPostal').value = operador.codigoPostal;
             document.getElementById('direccion').value = operador.direccion;
             document.getElementById('localidad').value = operador.localidad;
             document.getElementById('nivelPermiso').value = operador.nivelPermiso;
             document.getElementById('nombre').value = operador.nombre;
             document.getElementById('nroDocumento').value = operador.nroDocumento;
             document.getElementById('pais').value = operador.pais;
             document.getElementById('provincia').value = operador.provincia;
             document.getElementById('telefono').value = operador.telefono;
         }
         else {
             this.setState({ AgregarOperador: true });
             document.getElementById('codigoOperador').value ='Nuevo operador';
             //console.log('agregar operador es true');
             this.LimpiarCampos();
        }
    }

    CrearOperador() {

        var nroLegajo = document.getElementById('nroLegajo').value;
        var apellido= document.getElementById('apellido').value;
        var apellidoMaterno =document.getElementById('apellidoMaterno').value;
        var clave =document.getElementById('clave').value;
        var codigoDoc = document.getElementById('codigoDoc').value;
        var codigoOperador=document.getElementById('codigoOperador').value;
        var codigoPostal=document.getElementById('codigoPostal').value ;
        var direccion=document.getElementById('direccion').value;
        var localidad = document.getElementById('localidad').value;

        var nivelPermiso = document.getElementById('nivelPermiso').value;
        nivelPermiso = nivelPermiso.substr(0, nivelPermiso.indexOf('-'));

        var nombre=document.getElementById('nombre').value;
        var nroDocumento=document.getElementById('nroDocumento').value;
        var pais=document.getElementById('pais').value;
        var provincia=document.getElementById('provincia').value;
        var telefono = document.getElementById('telefono').value;
        
        fetch('http://localhost:61063/api/Operadors/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                nroLegajo: nroLegajo,
                apellido: apellido,
                apellidoMaterno: apellidoMaterno,
                clave: clave,
                codigoDoc: codigoDoc,
                codigoOperador: codigoOperador,
                codigoPostal: codigoPostal,
                direccion: direccion,
                localidad: localidad,
                nivelPermiso: nivelPermiso,
                nombre: nombre,
                nroDocumento: nroDocumento,
                pais: pais,
                provincia: provincia,
                telefono: telefono,

            })
        }).then(function (response) {
            if (response.ok) {
                alert('Usuario creado con exito');
            }
            else {
                alert('Algo salio mal');
            }
            });
        this.LimpiarCampos();
    }

    LimpiarCampos() {
        document.getElementById('codigoOperadortxt').value = '';
        document.getElementById('nroLegajo').value='';
        document.getElementById('apellido').value = '';
        document.getElementById('apellidoMaterno').value = '';
        document.getElementById('clave').value = '';
        document.getElementById('codigoDoc').value = '';
        document.getElementById('codigoPostal').value = '';
        document.getElementById('direccion').value = '';
        document.getElementById('localidad').value = '';
        document.getElementById('nombre').value = '';
        document.getElementById('nroDocumento').value = '';
        document.getElementById('pais').value = '';
        document.getElementById('provincia').value = '';
        document.getElementById('telefono').value = '';
    }

    EliminarOperador() {
        var IdBorrar = document.getElementById('codigoOperadortxt').value;
        if (IdBorrar === '') {
            alert('No ha seleccionado ningun operador');
        } else {
            fetch('http://localhost:61063/api/Operadors/' + IdBorrar, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    id: IdBorrar,
                })
            }).then(function (response) {
                if (response.ok)
                    alert('Borrado con exito');
                else
                    alert('Algo salio mal');
                });
            this.LimpiarCampos();
        }
    }

    ModificarOperador() {
        var nroLegajo = document.getElementById('nroLegajo').value;
        var apellido = document.getElementById('apellido').value;
        var apellidoMaterno = document.getElementById('apellidoMaterno').value;
        var clave = document.getElementById('clave').value;
        var codigoDoc = document.getElementById('codigoDoc').value;

        var codigoOperador = document.getElementById('codigoOperador').value;
        codigoOperador = codigoOperador.substr(0, codigoOperador.indexOf('-'));

        var codigoPostal = document.getElementById('codigoPostal').value;
        var direccion = document.getElementById('direccion').value;
        var localidad = document.getElementById('localidad').value;

        var nivelPermiso = document.getElementById('nivelPermiso').value;
        nivelPermiso = nivelPermiso.substr(0, nivelPermiso.indexOf('-'));

        var nombre = document.getElementById('nombre').value;
        var nroDocumento = document.getElementById('nroDocumento').value;
        var pais = document.getElementById('pais').value;
        var provincia = document.getElementById('provincia').value;
        var telefono = document.getElementById('telefono').value;

        fetch('http://localhost:61063/api/Operadors/' + codigoOperador, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                id: codigoOperador,
                nroLegajo: nroLegajo,
                apellido: apellido,
                apellidoMaterno: apellidoMaterno,
                clave: clave,
                codigoDoc: codigoDoc,
                codigoOperador: codigoOperador,
                codigoPostal: codigoPostal,
                direccion: direccion,
                localidad: localidad,
                nivelPermiso: nivelPermiso,
                nombre: nombre,
                nroDocumento: nroDocumento,
                pais: pais,
                provincia: provincia,
                telefono: telefono,
            })
        }).then(function (response) {
            if (response.ok)
                alert('Modificado con exito');
            else
                alert('Algo salio mal');
        });
    }

    buttonPadding = { padding: 20}

    render() {
        return (
            <div>
                <div className="darSeparacion">
                    <h1>Operadores</h1>
                    <table>
                        <tr>
                            <td>Codigo Operador</td>
                            <td><input id="codigoOperadortxt" className="form-control" type="text" /></td>
                            <td><select onChange={() => { this.SeleccionarOperador() }} className="form-control" id="codigoOperador">
                                <option defaultValue>Nuevo operador</option>
                                {
                                    this.state.operadores.map((item, index) => (
                                        <option key={index}> {item.codigoOperador + ' - ' + item.apellido} </option>
                                    ))
                                }
                                </select>
                                </td>
                        </tr>
                        <tr>
                            <td>N° Legajo</td>
                            <td><input id="nroLegajo" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Nombres</td>
                            <td><input id="nombre" className="form-control" type="text" /></td>
                        </tr>
                       
                        <tr>
                            <td>Apellido paterno</td>
                            <td><input id="apellido" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Apellido materno</td>
                            <td><input id="apellidoMaterno" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Direccion</td>
                            <td><input id="direccion" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Localidad</td>
                            <td><input id="localidad" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Codigo postal</td>
                            <td><input id="codigoPostal" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Provincia</td>
                            <td><input id="provincia" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Pais</td>
                            <td><input id="pais" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Telefonos</td>
                            <td><input id="telefono" className="form-control" type="text" /></td>
                        </tr>
                        <tr>
                            <td>Documento</td>
                            <td> <select id="codigoDoc" className="form-control">
                                {this.state.tipoDocumento.map((item, index) => (
                                    <option value={item.CodigoDoc}> {item.descDoc} </option>

                                ))
                                }
                            </select> </td>
                            <td><input id="nroDocumento" className="form-control" type="text" placeholder="1111111-1" /></td>
                        </tr>
                        <tr>
                            <td>Nivel Seguridad</td>
                            <td> <select id="nivelPermiso" className="form-control">
                                {this.state.NivelSeguridad.map((item, index) => (
                                    <option defaultValue> {item.nivelPermiso + ' - ' + item.descripcion} </option>

                                ))
                                }
                            </select> </td>
                        </tr>
                        <tr>
                            <td>Contraseña</td>
                            <td><input id="clave" className="form-control" type="password" /></td>
                        </tr>
                    </table>
                    <button  className="btn btn-success" onClick={() => { this.CrearOperador() }} >Guardar</button>
                    <button className="btn btn-danger" onClick={() => { this.EliminarOperador() }} >Eliminar</button>
                    <button className="btn btn-primary" onClick={() => { this.ModificarOperador() }} >Editar</button>
                </div>
                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
