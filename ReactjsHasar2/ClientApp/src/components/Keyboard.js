import React, { Component } from 'react';

import './EstilosKeyboard.css';
import { Link } from 'react-router-dom';


export class Keyboard extends Component {
    displayName = Keyboard.name
    
    constructor() {
        super();
        this.state = {
            productos: [],
            precioTotal: 0,
            formaPago: [],
            mostrarPago: false,
            saldo:0,
        }
        
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
                const url = 'http://localhost:61063/api/plu/' + codigo;
                var existe = await fetch(url);
                var data = await existe.json();
                var productosActualizados = this.state.productos;
                var total = this.state.precioTotal;
                total = total + Number(data['costo']);

                productosActualizados.push(data);


                this.setState({ productos: productosActualizados, precioTotal: total, saldo: total });
                document.getElementById('codigo').value = '';
            } catch (err) {
                alert('elemento no existe');
            }
        }
        else {
            alert('el campo codigo no puede estar en blanco');
        }
        
    }

    async RegistrarVentas() {
        var listaProd = this.state.productos;

        const formaPago = this.state.formaPago[0].forma;//cambiar cuando se agregen medios de pagos
        listaProd.map(function (item, i) {
            fetch('http://localhost:61063/api/Hist_plu', {
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
        //this.EnviarFacturasApiSII();
        this.UsarFolioEnvioSii();
        alert('Ventas guardadas con exito');
    }

    EnviarFacturasApiSII(numFolio) {//envia xml a la api de facturacion electronica de hasar
        const tipoDte = document.getElementById('tipoDocumento').value;
        fetch('http://localhost:61063/enviarDTE', {//dteController
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ detalles: this.state.productos, numFolio: numFolio, tipoDocumento: tipoDte }),
        }).then(() => this.setState({ productos: [], precioTotal: 0 }));
    };

    ImprimirBoleta(listaProd) {//recibe una lista de objectos tipo plu(producto)
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.innerHTML = 'print(' + JSON.stringify(listaProd) + ');';
        document.body.appendChild(script);
    }

    async UsarFolioEnvioSii() {
       
        const response = await fetch('http://localhost:61063/OperacionesFoliosLocales/UsarFolio', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
        })
        const data = await response.json();
        var numFolio = data.folioUsado;
        this.EnviarFacturasApiSII(numFolio);
        this.GuardarNuevaVenta(numFolio);
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
        var total = document.getElementById('total');
        var pago = document.getElementById('pagar');

        
        var sumatoriaPagos = 0;
        var pagos = this.state.formaPago;

        pagos.forEach(function (element) {
            sumatoriaPagos = sumatoriaPagos + element.valor;
        });
        if ((total.value - pago.value) < 0 || sumatoriaPagos > total) {
            alert('el pago no puede ser mayor al total');
        }
        else {
            var saldo = this.state.saldo - pago.value;

            document.getElementById('saldo').value = (total.value - pago.value);
            pagos.push({ forma: idMedioPago, valor: pago.value });
            document.getElementById('pagar').value = '';
            this.setState({ formaPago: pagos, saldo: saldo });
        }
        
        
    }

    estiloCasillaPago = {
        padding: '70px',
        border: '1px solid black',
        'padding-top': '10px'

    }

    GuardarNuevaVenta(numFolio) {//inserta en la tabla hist_fn
        console.log(this.state.productos);
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
            });
        });
        this.GuardarMediosDePagoVenta(numFolio);
    }

    GuardarMediosDePagoVenta(numFolio) {//guarda todos los medios de pagos usados para la venta
        const mediosPago = this.state.formaPago;
        mediosPago.forEach(function (currentValue, index, array) {
            fetch('http://localhost:61063/api/RelacionPagosProductos', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    NumFolio: numFolio,
                    IdMedioPago: currentValue.forma,
                    Monto: currentValue.valor
                })
            });
        });
    }

    async GetMedioPagoById(idMedioPago) {
        const url = "http://localhost:61063/api/MediosDePagoes/" + idMedioPago;
        const response = await fetch(url);
        const data = await response.json();
        return await data.descripcion;
    }

    ClickGetTotal() {
        const saldo = this.state.saldo;
        document.getElementById('pagar').value = saldo;
    }

    render() {
        return (
            <div>
                <div id="encabezado">
                    <p> Operador 9999 -Administrador</p>
                    <p>Cliente: Consumidor final <button className="btn btn-secondary">Ver clientes</button> </p>
                    <p>Tipo documento
                        <select id="tipoDocumento">
                            <option value="33">Boleta electronica</option>
                            <option value="39">Factura</option>
                        </select>
                    </p>
                </div>
                <div id="cuerpo">
                    <p> Ingrese codigo del producto  <input type="number" className="" placeholder="codigo" name="codigo" id="codigo" />
                        <button className="btn btn-success" onClick={() => this.VerificarExistencia()}>Agregar</button>
                    </p>
                    <div></div>
                    <table className="tablaNormal" id="productos">
                        <tr id="tr">
                            <th className="tablaNormal">N°</th>
                            <th className="tablaNormal">Codigo</th>
                            <th className="tablaNormal">Codigo de barra</th>
                            <th className="tablaNormal">Descripcion</th>
                            <th className="tablaNormal">Precio</th>
                            <th className="tablaNormal">Cantidad</th>
                        </tr>
                        <tbody>
                            {
                                this.state.productos.map(function (item, i) {
                                    return <tr key={i}>
                                        <td className="tablaNormal">{i + 1}</td>
                                        <td className="tablaNormal">  {item.codigoScanner} </td>
                                        <td className="tablaNormal"> {item.codigoScanner} </td>
                                        <td className="tablaNormal"> {item.descripcion} </td>
                                        <td className="tablaNormal"> {item.costo} </td>
                                        <td className="tablaNormal"> 1 </td>
                                    </tr>
                            })
                            }
                        </tbody>
                    </table>
                    
                </div>
                <center>
                    <p id="btnPagar">Precio total {this.state.precioTotal}  </p>
                    {this.state.precioTotal > 0 ? (<button id="btnPagar" className="btn btn-success"  onClick={() => this.setState({ mostrarPago: true })}>Pagar</button>)
                        : (<button disabled id="btnPagar" className="btn btn-success" onClick={() => this.setState({ mostrarPago: true })}>Pagar</button>)}

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
                                        <td style={this.padding}> <button value="asd" onClick={() => { this.RegistrarVentas() }} > Aceptar</button></td>
                                    </tr>
                                    <tr>
                                        <td style={this.padding}>Total</td>
                                        <td style={this.padding}> <input id="total" readOnly type="number" value={this.state.precioTotal} /> </td>
                                        <td style={this.padding}> <button onClick={() => { this.setState({ mostrarPago:false }) }} > Cancelar</button></td>
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
                            <button onClick={() => { this.AgregarPago(5) }}>Tarjeta credito</button>
                            <button onClick={() => { this.AgregarPago(10) }}>Cheque al dia </button>
                            <button onClick={() => { this.AgregarPago(11) }}>Cheque al fecha </button>
                            <button onClick={() => { this.AgregarPago(1) }}>Ticket</button>
                            <button onClick={() => { this.AgregarPago(9) }}>Cuenta corriente</button>
                        </div>
                    ): (<div></div>)
                }
                
                
            </div>
        );
    }
}
