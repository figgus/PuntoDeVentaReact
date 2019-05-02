import React, { Component } from 'react';
import './TotalVendido.css';
import { Link } from 'react-router-dom';

export class TotalVendido extends Component {
    displayName = TotalVendido.name

    constructor() {
        super();
        this.state = {
            productosVendidos: [],
            categorias: []
        };
        this.ListarVentasDelDia();
    }

    async ListarVentasDelDia() {
        const url = "http://localhost:61063/api/Hist_plu";
        const response = await fetch(url);
        var data = await response.json();

        this.setState({ productosVendidos: data });
        this.ListarCategorias();
    }

    async ListarCategorias() {

        var productos = this.state.productosVendidos;

        for (var i = 0; i < productos.length; i++) {
            var url = "http://localhost:61063/api/SubfuncionsCategorias/" + productos[i]['codigoPLU'];
            const response = await fetch(url);
            var data = await response.json();
            productos[i]['categoriaProd'] = data['descSubFn'];
        }
        console.log('las categorias en bruto son');
        console.log(this.CategoriasBruto(productos));
        this.setState({ productosVendidos: productos, categorias: this.RemoverDuplicados(this.CategoriasBruto(productos))});
        console.log(this.state);
    }



    GetTotal() {
        var productos = this.state.productosVendidos;
        var cont = 0;
        productos.forEach(function (element) {
            cont = cont + element['monto'];
        })
        return cont;
    }

    RemoverDuplicados(arreglo) {
        //console.log(arreglo);
        for (var i = 0; i < arreglo.length; i++) {
            for (var a = 0; a < arreglo.length; a++) {
                if (arreglo[i] == arreglo[a] && i!==a) {
                    //console.log('se borrara ' + arreglo[a]);
                    arreglo.splice(a, 1);
                    a--;
                }
            }
        }
        return arreglo;
    }

    CategoriasBruto(arreglo) {
        var res = [];
        for (var i = 0; i < arreglo.length; i++) {
            res.push(arreglo[i]['categoriaProd']);
        }
        return res;
    }

    TotalPorCategoria(nomCategoria) {
        var categorias = this.state.categorias;
        var ventas = this.state.productosVendidos;
        var cont = 0;
        ventas.forEach(function (element) {
            if (element['categoriaProd'] == nomCategoria) {
                cont = cont + element['monto'];
            }
        });
        return cont;
    }

    CantidadPorCategoria(nomCategoria) {
        var ventas = this.state.productosVendidos;
        var cont = 0;
        ventas.forEach(function (element) {
            if (element['categoriaProd'] === nomCategoria) {
                cont++;
            }
        });
        return cont;
    }

    render() {
        return (
            <div id="PorDepartamentos">
                <h1>Total vendido</h1>
                <h2>Departamentos</h2>
                <table className="tablaNormal">
                    <thead>
                        <tr>
                            <td className="tablaNormal"> N° </td>
                            <td className="tablaNormal">Descripcion</td>
                            <td className="tablaNormal">Cantidad</td>
                            <td className="tablaNormal">Monto</td>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.categorias.map((item, index) => (
                                <tr key={index}>
                                    <td className="tablaNormal">{index + 1}</td>
                                    <td className="tablaNormal">{item} </td>
                                    <td className="tablaNormal">{this.CantidadPorCategoria(item)}</td>
                                    <td className="tablaNormal"> {this.TotalPorCategoria(item)} </td>
                        </tr>
                            ))
                            
                            
                        }
                        <tr>
                            <td></td>
                            <td></td>
                            <td>Total</td>
                            <td>{this.GetTotal()}</td>
                        </tr>
                        
                    </tbody>
                </table>
                <h2>Medios de pago</h2>
                <table >
                    <tr>
                        <th>N°</th>
                        <th>Medio de pago</th>
                        <th>Monto total</th>
                    </tr>
                    
                </table>
                <p></p>
                <Link to="/menu"><button className="btn btn-secondary">Cerrar</button></Link>
                      
            </div>
        );
    }
}
