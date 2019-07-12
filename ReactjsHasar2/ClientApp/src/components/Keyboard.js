import React, { Component } from 'react';

import './EstilosKeyboard.css';
import { GetUrlLocal } from './Globales/VariblesGlobales';
import { GetUrlApi } from './Globales/VariblesGlobales';

import { Link } from 'react-router-dom';
import swal from 'sweetalert';
import Popup from "reactjs-popup";



export class Keyboard extends Component {
    displayName = Keyboard.name
    
    constructor() {
        super();
        this.state = {
            productos: [],
            precioTotal: 0,
            formaPago: [],
            mostrarPago: false,
            saldo: 0,
            listaMedios: [],//lista de los medios de pago disponibles en bd
            documentosSii: [],
            docSeleccionado:null,
        }
        this.TraerMediosPago();
        this.TraerDocsSii();
    }

    componentDidMount() {
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.innerHTML = 'Cargar();';
        document.body.appendChild(script);


    }



    async VerificarExistencia() {
        var codigo = document.getElementById('codigo').value;
        if (codigo != '' || codigo>0) {
            try {
                const url = GetUrlLocal()+'/api/plu/' + codigo;
                var existe = await fetch(url);
                var data = await existe.json();
                var productosActualizados = this.state.productos;
                var total = this.state.precioTotal;
                total = total + Number(data['costo']);

                productosActualizados.push(data);
                

                this.setState({ productos: productosActualizados, precioTotal: total, saldo: total });
                document.getElementById('codigo').value = '';
            } catch (err) {
                swal("El codigo de barras ingresado no esta registrado");
            }
        }
        else {
            swal("El campo codigo no puede estar en blanco");
        }
        
        
    }

    async RegistrarVentas() {
        var listaProd = this.state.productos;

        const formaPago = this.state.formaPago[0].forma;//cambiar cuando se agregen medios de pagos
        listaProd.map(function (item, i) {
            fetch(GetUrlLocal()+'api/Hist_plu', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    Monto: item['costo'],
                    CodigoPLU: item['codigoPLU'],
                    MedioPago: formaPago,
                })
            })
        });
        
        this.ImprimirBoleta(listaProd);
        swal({
            title: "Venta Terminada!",
            text: "¡Venta Guardada con exito!",
            icon: "success",
        });
        //swal("Ventas guardadas con exito");
    }

    async EnviarFacturasApiSII(/*numFolio*/) {//envia xml a la api de facturacion electronica de hasar
        const tipoDte = Number( document.getElementById('tipoDocumento').value);
        console.log(tipoDte);
        var data = {};
        data.tipoDocumento = tipoDte;
        data.detalles = this.state.productos;
        if (document.getElementById('RutCliente')!==null) {
            data.RutCliente = document.getElementById('RutCliente').value;
        }
        
        if (tipoDte === 43) {
            data.TpoDocLiq=document.getElementById('TpoDocLiq').value;
        }
        if(tipoDte === 50) {
            data.IndTraslado=document.getElementById('IndTraslado').value;
            data.CmnaDest = document.getElementById('CmnaDest').value;
        }
        console.log(data);
        //for (var p of formulario) {
        //    console.log(p);
        //}
        var respuesta = await fetch(GetUrlLocal()+'/enviarDTE', {//dteController
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        if (respuesta.ok) {
            const resp = await respuesta.json();
            
            console.log(resp.numeroFolio);
            this.GuardarNuevaVenta(resp.numeroFolio);
        }
        else {
            console.log('EnviarFacturasApiSII fallo');
        }
        this.setState({ productos: [], precioTotal: 0, mostrarPago: false });
    };


    //async ImprimirFacturaPDF(textoXml) {
        
    //    const url = "http://localhost:61063/dte/ImprimirFactura";
    //    const response = await fetch(url, {
    //        method: 'POST',
    //        headers: {
    //            'Content-Type': 'application/json',
    //        },
    //        body: JSON.stringify({ xml: textoXml }),
    //    });
    //    if (response.ok) {
    //        console.log('imprimir factura ejecutado con exito');
    //    }

    //    //const data = await response.json();
    //}

    ImprimirBoleta(listaProd) {//recibe una lista de objectos tipo plu(producto)
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.innerHTML = 'print(' + JSON.stringify(listaProd) + ');';
        document.body.appendChild(script);
    }

    //async UsarFolioEnvioSii() {//se llama al hacer click en , quizas borrar
       
    //    const response = await fetch('http://localhost:61063/OperacionesFoliosLocales/UsarFolio', {
    //        method: 'POST',
    //        headers: {
    //            'Content-Type': 'application/json',
    //        },
    //    }).then((response) => {
    //        if (response.ok) {
    //            this.EnvioNumeroFolio(response);
    //        }
    //        else {
    //            swal('No hay folios disponibles, por favor solicite mas');
    //        }
    //        });
        
    //}

    async EnvioNumeroFolio(/*response*/) {//llama las funciones despues de obtenerse el numero de folio, se llama en el callback de UsarFolioEnvioSii
        //const data = await response.json();
        //var numFolio = data.folioUsado;
        try {
            if (this.state.docSeleccionado === null)
                throw 'Seleccione un tipo de documento';
            const solicitudFolio = await this.EnviarFacturasApiSII(1);//hace que retorne el numero de folio asignado


            this.RegistrarVentas();
            this.ResetState();
        } catch (err) {
            swal(String( err));
        }
        
    }

        
    

    Redirigir(url) {
        //this.props.children.push('Menu');
        this.props.history.push(url);
    }

    estiloTabla = {
        border: '1px solid black',
        'border-collapse': 'collapse',
        padding: '15px'
    }

    padding = {
        padding: '7px'
    }

    AgregarPago(idMedioPago) {
        try {
            var total = document.getElementById('total');
            var pago = document.getElementById('pagar');
            var saldo = this.state.saldo - pago.value;

            if ((this.state.saldo - pago.value) < 0) {
                throw 'No puede pagar mas que el saldo restante';
            }

            var sumatoriaPagos = 0;
            var pagos = this.state.formaPago;
            pagos.forEach(function (element) {
                sumatoriaPagos = sumatoriaPagos + element.valor;
            });
            if ((total.value - pago.value) < 0 || sumatoriaPagos > total) {
                swal('el pago no puede ser mayor al total');
            }
            else {



                document.getElementById('saldo').value = (total.value - pago.value);
                pagos.push({ forma: idMedioPago, valor: pago.value });
                document.getElementById('pagar').value = '';
                this.setState({ formaPago: pagos, saldo: saldo });
            }
        } catch (err) {
            swal(err);
        }
        
    }

    estiloCasillaPago = {
        padding: '70px',
        border: '1px solid black',
        'padding-top': '10px',
        'background-color': 'cadetblue'
    }

    GuardarNuevaVenta(numFolio) {//inserta en la tabla hist_fn
        const prods = this.state.productos;
        
        

        prods.forEach(function (currentValue, index, array) {
            
            fetch('http://localhost:61063/api/Hist_fn', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                        CodPLU: currentValue.codigoPLU,
                        Cantidad: 1,
                        Monto: currentValue.costo,
                        CategoriaFk: currentValue.codigoSeccion,
                    numeroFolio: numFolio,
                })
            }).then(function (response) { if (!response.ok) { console.log('venta no guardada') } });
        });
        this.GuardarMediosDePagoVenta();
    }

    GuardarMediosDePagoVenta() {//guarda todos los medios de pagos usados para la venta
        console.log('GuardarMediosDePagoVenta');
        const mediosPago = this.state.formaPago;
        mediosPago.forEach(function (currentValue, index, array) {
            fetch(GetUrlLocal()+'/api/RelacionPagosProductos', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    IdMedioPago: currentValue.forma,
                    Monto: currentValue.valor
                })
            });
        });
    }

    
    //-- Acciones de Onclick
    ClickGetTotal() {
        const saldo = this.state.saldo;
        document.getElementById('pagar').value = saldo;
    }

    ClickCancelar() {
        this.setState({ mostrarPago: false });
        this.ResetMediosDePago();
    }

    ChangeDocSii() {
        const doc = document.getElementById('tipoDocumento').value;
        this.setState({ docSeleccionado: Number( doc) });
        
    }

    //-- fin Acciones de Onclick

    ResetState() {
        this.setState({
            productos: [],
            precioTotal: 0,
            formaPago: [],
            mostrarPago: false,
            saldo: 0,
        });
    }

    ResetMediosDePago() {
        this.setState({
            formaPago: [],
            saldo: 0,
        });
    }

    //-----Traer datos db
     GetMedioPagoById(idMedioPago) {
         let lista = this.state.listaMedios;
         return (lista.filter(p => p.id === idMedioPago))[0].descripcion;
    }

    async TraerMediosPago() {
        const url = GetUrlLocal()+"/api/MediosDePagoes/";
        const response = await fetch(url);
        const data = await response.json();
        var lista = [];
        data.forEach((currentValue) => {
            lista.push(currentValue);
        });
        this.setState({ listaMedios: lista });
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


    //-----fin Traer datos db

    //------>Funciones html
    GetHtmlOpcional() {
        try {
            const docSelect = this.state.docSeleccionado;
            if (docSelect === 33 || docSelect===34) {
                return (
                    <p>
                        {this.HtmlInfoCliente()}
                    </p>
                );
                
            }
            if (docSelect === 50) {
                return (<div>
                    <p> Indicador de traslado de bienes
                                <select id="IndTraslado">
                        <option value="1"> Operación constituye venta </option>
                        <option value="2"> Ventas por efectuar </option>
                        <option value="3"> Consignaciones </option>
                        <option value="4"> Entrega gratuita </option>
                        <option value="5"> Traslados internos </option>
                        <option value="6">  Otros traslados noventa</option>
                        <option value="7"> Guía de devolución </option>
                        <option value="8">  Traslado para exportación </option>
                        <option value="9"> Venta para exportación  </option>
                        </select>
                    </p>

                    <p>Comuna de destino
                        <input type="text" id="CmnaDest"/>
                        </p>
                </div>);
                
            }
            if (docSelect ===43) {
                return (<div>
                    Indique el tipo de documento que se liquida
                    <select  className="form-control form-control-sm" id="tipoDocumento">
                        <option value="0">-- Seleccione</option>
                        {
                            this.state.documentosSii.map(function (item, i) {
                                return <option value={item.id}> {item.descripcion}</option>
                            })
                        }

                    </select>
                     
                </div>);
            }

            if (docSelect===55) {
                return (<div>
                    Indique el codigo de referencia
                    <select className="form-control form-control-sm" id="tipoDocumento">
                        <option value="1">Anula Documento de Referencia</option>
                        <option value="2">Corrige Texto Documento de Referencia</option>
                        <option value="3"> Corrige montos</option>
                        

                    </select>
                    <p>
                        Tipo de documento a modificar
                        {this.HtmlSeleccionarTipoDocumento()}
                        {this.HtmlFolioReferencia()}
                    </p>
                </div>);
            }
            if (docSelect === 60) {//nota de credito
                return (<div>
                    {this.HtmlCodigoReferencia()}
                    <p>
                        Tipo de documento a modificar
                        {this.HtmlSeleccionarTipoDocumento()}
                        {this.HtmlFolioReferencia()}
                    </p>
                </div>);
            }
        } catch (err) {
            return (<div></div>);
        }

    }

    HtmlSeleccionarTipoDocumento() {
        return (<select className="form-control form-control-sm" id="tipoDocumento">
            <option value="0">-- Seleccione</option>
            {
                this.state.documentosSii.map(function (item, i) {
                    return <option value={item.id}> {item.descripcion}</option>
                })
            }

        </select>);
    }

    HtmlFolioReferencia() {
        return (
        <form className="form-inline">
            <div className="form-group mb-2" id="encabezado">
                <p>Ingrese el numero de folio de la venta
                            <input className="form-control form-control-sm" id="numFolio"></input>
                </p>
             </div>
        </form>);
    }

    HtmlCodigoReferencia() {
        return (
            <p>Indique el codigo de referencia
                < select className = "form-control form-control-sm" id = "tipoDocumento" >
                    <option value="1">Anula Documento de Referencia</option>
                    <option value="2">Corrige Texto Documento de Referencia</option>
                    <option value="3"> Corrige montos</option>


                </select >
            </p>
            );
    }

    HtmlInfoCliente() {
        return (<div>
            Rut del cliente
                <input className="form-control form-control-sm" type="text" id="RutCliente" />
        </div>
        );
    }
    //------->Fin funciones html

    render() {
        return (
            <div>
                <form className="form-inline">
                    <div className="form-group mb-2" id="encabezado">
                        <p> Operador 9999 -Administrador</p>
                        <p>Cliente: Consumidor final <button className="btn btn-secondary">Ver clientes</button> </p>
                        
                        <p>Tipo documento
                            <select onChange={() => { this.ChangeDocSii() }} className="form-control form-control-sm" id="tipoDocumento">
                                <option value="0">-- Seleccione</option>
                                {
                                    this.state.documentosSii.map(function (item, i) {
                                        return <option value={item.id}> {item.descripcion}</option>
                                    })
                                }
                                
                            </select>
                        </p>

                        {
                            this.state.docSeleccionado !==null ? (this.GetHtmlOpcional()) : (<div></div>)
                        }
                    </div>
                </form>
                <div id="cuerpo">
                    <p> Ingrese codigo del producto  <input type="number" className="" placeholder="codigo" name="codigo" id="codigo" />
                        <button className="btn btn-success" onClick={() => this.VerificarExistencia()}>Agregar</button>
                    </p>
                    <div></div>
                    <table className="table" id="productos">
                        <thead>
                            <tr id="tr">
                                <th >N°</th>
                                <th >Codigo</th>
                                <th >Codigo de barra</th>
                                <th >Descripcion</th>
                                <th >Precio</th>
                                <th >Cantidad</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.productos.map(function (item, i) {
                                    return <tr key={i}>
                                        <td>{i + 1}</td>
                                        <td>  {item.codigoScanner} </td>
                                        <td> {item.codigoScanner} </td>
                                        <td> {item.descripcion} </td>
                                        <td> {item.costo} </td>
                                        <td> 1 </td>
                                    </tr>
                                })

                            }
                        </tbody>
                    </table>
                    
                </div>
                <center>
                    <Popup
                        trigger={<button id="btnPagar" className="btn btn-success" onClick={() => this.setState({ mostrarPago: true })}>Pagar</button>}
                        modal
                        closeOnDocumentClick>
                        <div style={this.estiloCasillaPago}>
                            <table className="aDerecha">
                                <tbody>
                                    <tr>
                                        <td style={this.padding}>Percepciones</td>
                                        <td style={this.padding}></td>
                                        <td style={this.padding}></td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>Ofertas</td>
                                        <td style={this.padding}></td>
                                        <td style={this.padding}> <button value="asd" onClick={() => { this.EnvioNumeroFolio() }} > Aceptar</button></td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>Total</td>
                                        <td style={this.padding}> <input id="total" readOnly type="number" value={this.state.precioTotal} /> </td>
                                        <td style={this.padding}> <button onClick={() => { this.ClickCancelar(); }} > Cancelar</button></td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>A pagar</td>
                                        <td style={this.padding}> <input onDoubleClick={() => { this.ClickGetTotal() }} id="pagar" type="number" /> </td>
                                        <td style={this.padding}> <button value="asd" > Descuentos total</button> </td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>Saldo</td>
                                        <td style={this.padding}> <input id="saldo" type="number" value={this.state.saldo} /> </td>
                                        <td style={this.padding}> </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style={this.estiloTabla}>
                                <thead>
                                    <th style={this.estiloTabla}> Forma </th>
                                    <th style={this.estiloTabla}> Valor </th>
                                </thead>
                                {
                                    this.state.formaPago.map((item, i) => {
                                        return <tr key={i}>
                                            <td style={this.estiloTabla} >{String(this.GetMedioPagoById(item.forma))} </td>
                                            <td style={this.estiloTabla}>{item.valor} </td>

                                        </tr>
                                    })
                                }
                            </table>

                            <button onClick={() => { this.AgregarPago(1) }}>Efectivo</button>
                            <button onClick={() => { this.AgregarPago(1) }}>Otros pagos</button>
                            <button onClick={() => { this.AgregarPago(2) }}>Tarjeta credito</button>
                            <button onClick={() => { this.AgregarPago(6) }}>Cheque al dia </button>
                            <button onClick={() => { this.AgregarPago(7) }}>Cheque al fecha </button>
                            <button onClick={() => { this.AgregarPago(1) }}>Ticket</button>
                            <button onClick={() => { this.AgregarPago(1) }}>Cuenta corriente</button>
                        </div>
                    </Popup>
                </center>
                <Link to="/menu"><button className="btn btn-secondary">Cerrar</button></Link>
                {
                    this.state.mostrarPago ? (
                        <div style={this.estiloCasillaPago}>
                            <table className="aDerecha">
                                <tbody>
                                    <tr>
                                        <td style={this.padding}>Percepciones</td>
                                        <td style={this.padding}></td>
                                        <td style={this.padding}></td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>Ofertas</td>
                                        <td style={this.padding}></td>
                                        <td style={this.padding}> <button value="asd" onClick={() => { this.EnvioNumeroFolio() }} > Aceptar</button></td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>Total</td>
                                        <td style={this.padding}> <input id="total" readOnly type="number" value={this.state.precioTotal} /> </td>
                                        <td style={this.padding}> <button onClick={() => { this.ClickCancelar(); }} > Cancelar</button></td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>A pagar</td>
                                        <td style={this.padding}> <input onDoubleClick={() => { this.ClickGetTotal() }} id="pagar" type="number" /> </td>
                                        <td style={this.padding}> <button value="asd" > Descuentos total</button> </td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>Saldo</td>
                                        <td style={this.padding}> <input id="saldo" type="number" value={this.state.saldo} /> </td>
                                        <td style={this.padding}> </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style={this.estiloTabla}>
                                <thead>
                                    <th style={this.estiloTabla}> Forma </th>
                                    <th style={this.estiloTabla}> Valor </th>
                                </thead>
                                {
                                    this.state.formaPago.map( (item, i)=> {
                                        return <tr key={i}>
                                            <td style={this.estiloTabla} >{String(this.GetMedioPagoById(item.forma))} </td>
                                            <td style={this.estiloTabla}>{item.valor} </td>

                                        </tr>
                                    })
                                }
                            </table>

                            <button onClick={() => { this.AgregarPago(1) }}>Efectivo</button>
                            <button onClick={() => { this.AgregarPago(1) }}>Otros pagos</button>
                            <button onClick={() => { this.AgregarPago(2) }}>Tarjeta credito</button>
                            <button onClick={() => { this.AgregarPago(6) }}>Cheque al dia </button>
                            <button onClick={() => { this.AgregarPago(7) }}>Cheque al fecha </button>
                            <button onClick={() => { this.AgregarPago(1) }}>Ticket</button>
                            <button onClick={() => { this.AgregarPago(1) }}>Cuenta corriente</button>
                        </div>
                    ): (<div></div>)
                }
                
                
            </div>
        );
    }
}
