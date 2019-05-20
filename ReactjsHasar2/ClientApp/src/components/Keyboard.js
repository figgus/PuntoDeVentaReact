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
        

        //var script = document.createElement('script');
        //script.type = 'text/javascript';
        //script.innerHTML = 'Cargar();print();';
        //document.body.appendChild(script);
        
    }

    
    

    //GuardarVenta(montoVenta) {
    //    this.setState({ enviado: true });
    //    var producto = document.getElementById('producto').value;
    //    fetch('http://localhost:61063/api/valores/', {
    //        method: 'POST',
    //        headers: {
    //            'Content-Type': 'application/json',
    //        },
    //        body: JSON.stringify({
    //            Monto: montoVenta,
    //            producto: producto,
    //        }),
    //    })
    //}

    async VerificarExistencia() {
        var codigo = document.getElementById('codigo').value;
        if (codigo != '') {
            const url = 'http://localhost:61063/api/plu/' + codigo;
            console.log(url);
            var existe = await fetch(url);
            var data = await existe.json();

            if (data != '') {

                var productosActualizados = this.state.productos;
                var total = this.state.precioTotal;
                console.log('el primer total es ' + total);
                console.log('y se le suma ' + data['costo']);
                total = total + Number(data['costo']);

                productosActualizados.push(data);


                this.setState({ productos: productosActualizados, precioTotal: total, saldo: total });
                document.getElementById('codigo').value = '';

            }
            else {
                alert('elemento no existe');
            }
        }
        else {
            alert('el campo codigo no puede estar en blanco');
        }
        
    }

    async RegistrarVentas() {
        var listaProd = this.state.productos;

        const formaPago = this.state.formaPago[0].forma;
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
        //this.EnviarFacturasApiSII();
        alert('Ventas guardadas con exito');
        this.setState({ productos: [], precioTotal: 0 });
        
    }

    EnviarFacturasApiSII() {//envia xml a la api de facturacion electronica de hasar
        //console.log(JSON.stringify({ detalles: this.state.productos }));
         fetch('http://localhost:61063/enviarDTE', {//dteController
             method: 'POST',
             headers: {
                 'Content-Type': 'application/json',
             },
             body: JSON.stringify( this.state.productos ),
         })

    };


        
    

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
           // total.value = Number(total.value) - Number(pago.value);
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

    render() {
        return (
            <div>
                <div id="encabezado">
                    <p> Operador 9999 -Administrador</p>
                    <p>Cliente: Consumidor final <button className="btn btn-secondary">Ver clientes</button> </p>
                    <p>Tipo documento
                        <select>
                            <option>Boleta fiscal</option>
                        </select>
                    </p>
                </div>
                <div id="cuerpo">
                    <p> Ingrese codigo del producto  <input type="text" className="" placeholder="codigo" name="codigo" id="codigo" />
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

                    <button id="btnPagar" className="btn btn-success" onClick={() => this.setState({ mostrarPago:true })}>Pagar</button>
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
                                        <td style={this.padding}> <input id="pagar" type="number" /> </td>
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
                                    this.state.formaPago.map(function (item, i) {
                                        return <tr key={i}>
                                            <td  sty>{item.forma} </td>
                                            <td >{item.valor} </td>

                                        </tr>
                                    })
                                }
                                <tr>
                                    <td style={this.estiloTabla}></td>
                                    <td style={this.estiloTabla}></td>
                                </tr>

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

                <button onClick={() => { this.EnviarFacturasApiSII() }} className="btn btn-secondary">Enviar dte</button>
            </div>
        );
    }
}
