import React, { Component } from 'react';
//import './EstiloBotones.css';
import './EstilosKeyboard.css';
import { Link } from 'react-router-dom';

export class Keyboard extends Component {
    displayName = Keyboard.name
    
    //productos= []
    constructor() {
        super();
        this.state = {
            productos: [],
            precioTotal : 0
        }
    }

    
    

    GuardarVenta(montoVenta) {
        this.setState({ enviado: true });
        var producto = document.getElementById('producto').value;
        fetch('http://localhost:61063/api/valores/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Monto: montoVenta,
                producto: producto,
                
            }),
        })
    }

    async VerificarExistencia() {
        var codigo = document.getElementById('codigo').value;
        if (codigo != '') {
            const url = 'http://localhost:61063/api/plu/' + codigo;
            console.log(url);
            var existe = await fetch(url);
            var data = await existe.json();

            //alert('el numero de resultados es ' + count);
            if (data != '') {

                var productosActualizados = this.state.productos;
                var total = this.state.precioTotal;
                console.log('el primer total es ' + total);
                console.log('y se le suma ' + data['costo']);
                total = total + Number(data['costo']);

                productosActualizados.push(data);


                this.setState({ productos: productosActualizados, precioTotal: total });
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
       
        console.log('los productos son:');
        console.log(listaProd);

        fetch('http://localhost:61063/api/libro_iva', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                TotalOperacion: this.state.precioTotal,
            })
        })



        listaProd.map(function (item, i) {
            //console.log('el item es');
            console.log(item);
            fetch('http://localhost:61063/api/Hist_plu', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    Monto: item['costo'],
                    CodigoPLU: item['codigoPLU'],
                })
            })
        });

        this.setState({ productos: [], precioTotal: 0 });
        alert('ventas guardadas con exito');
        
    }

    Cerrar() {
        this.props.children.push('Menu');
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
                    <table id="productos">
                        <tr id="tr">
                            <th>N°</th>
                            <th>Codigo</th>
                            <th>Codigo de barra</th>
                            <th>Descripcion</th>
                            <th>Precio</th>
                            <th>Cantidad</th>
                        </tr>
                        <tbody>
                            {
                                this.state.productos.map(function (item, i) {
                                    console.log('el elemento es ');
                                    console.log(item);
                                    //console.log(item[i]);
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
                    <p id="btnPagar">Precio total {this.state.precioTotal}  </p>
                    <button id="btnPagar" className="btn btn-success" onClick={() => this.RegistrarVentas()}>Pagar</button>
                </center>
                <button className="btn btn-secondary"><Link to="/Menu">Cerrar</Link></button>
            </div>
        );
    }
}
