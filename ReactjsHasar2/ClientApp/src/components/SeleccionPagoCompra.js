import React, { Component } from 'react';
import './SeleccionPagoCompra.css';

export class SeleccionPagoCompra extends Component {

    //quizas Borrar
    displayName = SeleccionPagoCompra.name

    constructor(props) {
        super(props);
        this.state = { formaPago: [] };
        
    }
    estiloTabla = {
        border: '1px solid black',
        'border-collapse': 'collapse',
        padding: '15px'
    }

    padding = {
        padding: '7px'
    }

    CerrarMediosPago(url) {
        this.props.history.push(url);
    }

    render() {
        return (
            <div>
                <table className="aDerecha">
                    <tr>
                        <td style={this.padding}>Percepciones</td>
                        <td style={this.padding}></td>
                        <td style={this.padding}></td>
                    </tr>
                    <tr>
                        <td style={this.padding}>Ofertas</td>
                        <td style={this.padding}></td>
                        <td style={this.padding}> <button value="asd" > Aceptar</button></td>
                    </tr>
                    <tr>
                        <td style={this.padding}>Total</td>
                        <td style={this.padding}></td>
                        <td style={this.padding}> <button onClick={() => { this.CerrarMediosPago('/facturar') }} > Cancelar</button></td>
                    </tr>
                    <tr>
                        <td style={this.padding}>A pagar</td>
                        <td style={this.padding}> <input type="number" /> </td>
                        <td style={this.padding}> <button value="asd" > Descuentos total</button> </td>
                    </tr>
                </table>
                <table style={this.estiloTabla}>
                    <thead>
                        <th style={this.estiloTabla}> Forma </th>
                        <th style={this.estiloTabla}> Valor </th>
                    </thead>
                    {
                        this.state.formaPago.map(function (item, i) {
                            return <tr key={i}>
                                <td style={this.estiloTabla}></td>
                                <td style={this.estiloTabla}></td>
                                
                            </tr>
                        })
                    }
                    <tr>
                        <td style={this.estiloTabla}></td>
                        <td style={this.estiloTabla}></td>
                    </tr>
                   
                </table>
                
                

                <button>Efectivo</button>
                <button>Otros pagos</button>
                <button>Tarjeta credito</button>
                <button>Cheque</button>
                <button>Ticket</button>
                <button>Cuenta corriente</button>
            </div>
        );
    }
}
