import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import swal from 'sweetalert';
import { GetUrlLocal } from './Globales/VariblesGlobales';
import { GetUrlApi } from './Globales/VariblesGlobales';


export class Devoluciones extends Component {
    displayName = Devoluciones.name

    constructor() {
        super();
        this.state = {
            tipoDteUsado: 60,
            productos: [],
            folioIngresado: false,
            documentosSii: [],
            productosSeleccionados: [],
            filasEditar: [],
            cargando: false,
        };
        this.TraerDocsSii();
    }

    async TraerDocsSii() {
        try {
            const url = GetUrlApi() + "api/tipoDocumentos";
            const response = await fetch(url);
            if (!response.ok)
                throw 'No pudo traerse los tipos de documentos del sii';
            const data = await response.json();
            var lista = [];
            data.forEach((currentValue) => {
                lista.push(currentValue);
            });
            this.setState({ documentosSii: lista });
        } catch (err) {
            swal('No pudo traerse los tipos de documentos del sii');
        }
    }
    async VerificarExistenciaVenta() {
        try {
            const numFolio = document.getElementById('numFolio').value;
            if (numFolio.value === null || numFolio.value==='')
                throw 'Numero de folio invalido';
            const url = GetUrlApi() + "/api/detalles/";
            const response = await fetch(url);
            const data = await response.json();
            //console.log(data);
            var result = data.filter(data => data.numFolio == numFolio);
            //console.log(result);
            this.setState({ productos: result, folioIngresado: true });
        } catch (err) {
            swal(err);
        }
    }

    async EnviarNotaDeCredito() {
        try {
            this.BlockButtonAnular();
            var numProductosSeleccionados = document.getElementsByName('chkAnular');
            var continuar = false;
            numProductosSeleccionados.forEach(function (currentValue) {
                if (currentValue.checked) {
                    continuar = true;
                }
            });
            console.log(continuar);
            if (!continuar)
                throw 'No ha seleccionado ningun documento para anular';
            this.setState({ cargando: true });
            const tipoDte = 61;
            var data = {};
            data.tipoDocumento = tipoDte;

            var prods = [];
            const productos = this.state.productos;
            this.state.filasEditar.forEach(function (currentValue) {
                const cantAgregada = document.getElementsByName('cantidad')[currentValue];
                productos[currentValue].qtyItem = cantAgregada.value;
                const prodAgregar = productos[currentValue];
                prods.push(prodAgregar);
            });
            data.detalles = prods;

            const numFolio = document.getElementById('numFolio').value;
            data.numFolioReferencia = numFolio;

            const tipoDocumentoRef = document.getElementById('tipoDocumentoRef').value;
            data.tipoDocumentoRef = tipoDocumentoRef;

            data.CodRef = 1;



            console.log(data);

            var respuesta = await fetch(GetUrlLocal() + '/AnularVenta', {//dteController
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            });
            if (respuesta.ok) {
                try {
                    //const resp = await respuesta.json();
                    data = {};
                    data.numFolio = numFolio;
                    var TotalAnulacion = 0;
                    this.state.productos.forEach(function (currentValue) {
                        TotalAnulacion += currentValue.montoItem;
                    });
                    data.Monto = TotalAnulacion;
                    var respuesta = await fetch(GetUrlLocal() + '/api/AnulacionesVentas', {//dteController
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(data),
                    });
                    if (respuesta.ok)
                        swal('Operacion exitosa').then(() => { this.Redirigir('/menu')});
                    //console.log(resp);
                } catch (err) {
                    console.log(err);
                    swal('Problema con la respuesta de la api');
                }
            }
            else {
                swal('No pudo establecerse conexion con la API');
            }
        }
        catch (err) {
            swal(err);
        }
    }

    Redirigir(url) {
        //this.props.children.push('Menu');
        this.props.history.push(url);
    }

    HabilitarEdicionCantidad(numFila) {
        try {
            var cantidad = document.getElementsByName('cantidad')[numFila];
            cantidad.removeAttribute('ReadOnly');
            var filasEditar = this.state.filasEditar;
            filasEditar.push(numFila);
            this.setState({ filasEditar: filasEditar });
        } catch (err) {
            console.log(err);
        }
    }

    
    


    //-------->Funciones onclick
    ClickAnularVenta() {
        
        this.VerificarExistenciaVenta();

    }

    //-------->Funciones onclick

    //-------> Funciones HTML

    GetTablaProductos() {

        return (
            <div>

                <table className="table">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Descripcion</th>
                            <th size="4" scope="col">Cantidad</th>
                            <th scope="col">Precio</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.productos.map( (item, i)=> {
                                return <tr key={i}>
                                    <td>{i + 1}</td>
                                    <td> {item.nmbItem} </td>
                                    <td><input readOnly name="cantidad" size="4" className="form-control form-control-sm" defaultValue={item.qtyItem}></input>  </td>
                                    <td> {item.prcItem} </td>
                                    <td> <input type="checkbox" name="chkAnular" onClick={() => { this.HabilitarEdicionCantidad(i) }} value={i + 1} /></td>
                                </tr>
                            })
                        }
                    </tbody>
                </table>
                
                
            </div>
        );
    }

    GetTablaInfoCliente() {
        
         const tipo = this.state.tipoDteUsado;
        const emisor = this.state.productos[0].emisor;

        var rutEmpresa;
        if (emisor !== null)
            rutEmpresa = emisor.rutEmpresa;

        var razonSocial;
        if (emisor !== null)
            razonSocial = emisor.razonSocial;
        var giroNegocio;
        if (emisor !== null)
            giroNegocio = emisor.giroNegocio;
        
        console.log(this.state.productos);
            return (
                <div>
                    <strong> Informacion del cliente</strong>
                    <table className="table">
                        <thead>
                            <tr>
                                <th scope="col">Rut empresa</th>
                                <th scope="col">Razon social</th>
                                <th scope="col">Giro del negocio</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                               <tr>
                                    <td> {rutEmpresa} </td>
                                    <td> {razonSocial} </td>
                                    <td> {giroNegocio} </td>
                                </tr>

                            }

                        </tbody>
                    </table>
                </div>
            );
        
    }

    //---------> Fin funciones HTML

    BlockButtonAnular() {
        const boton = document.getElementById('btnAnular');
        boton.innerHTML = "Anulando por favor espere";
        boton.disabled = true;
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
                            <p>
                                Seleccione el tipo de documento: 
                                <select className="form-control form-control-sm" id="tipoDocumentoRef">
                                    <option value="0">-- Seleccione</option>
                                    {
                                        this.state.documentosSii.map(function (item, i) {
                                            return <option value={item.id}> {item.descripcion}</option>
                                        })
                                    }

                                </select>
                                <button type="button" onClick={() => { this.ClickAnularVenta() }} className="btn btn-success">Buscar</button>

                            </p>
                            {
                                (this.state.folioIngresado) ? (<div>{this.GetTablaInfoCliente()}</div>) : (<div></div>)
                            }
                            {this.GetTablaProductos()}
                            <p>
                                <button type="button" id="btnAnular" onClick={() => { this.EnviarNotaDeCredito()}} className="btn btn-danger">Anular</button>
                                {
                                    (this.state.cargando) ? (<div> <img height="50" alt="" width="50" src={require('./Imagenes/Cargando.gif')} /></div>) : (<div></div>)
                                }
                            </p>
                            </div>
                    </form>
                </center>
                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
