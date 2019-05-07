import React, { Component } from 'react';
import './TotalVendido.css';
import { Link } from 'react-router-dom';

export class TotalVendido extends Component {
    displayName = TotalVendido.name

    constructor() {
        super();
        this.state = {
            productosVendidos: [],
            categorias: [],
            filtroPorFecha: false
        };
        this.ListarVentasDelDia();
    }

    async ListarVentasDelDia() {
        const url = "http://localhost:61063/api/Hist_plu";
        const response = await fetch(url);
        var data = await response.json();
        console.log(data);
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
        this.setState({ productosVendidos: productos, categorias: this.RemoverDuplicados(this.CategoriasBruto(productos))});
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

    Filtrar() {
        if (!this.state.filtroPorFecha) {
            this.setState({ filtroPorFecha: true });
        }
        
    }

    NoFiltrar() {
        if (this.state.filtroPorFecha) {
            this.setState({ filtroPorFecha: false });
        }
    }

    async TraerDatosPorFecha() {
        var fechaSeleccionada = document.getElementById('fecha').value;
        const url = "http://localhost:61063/api/Zetas/" + fechaSeleccionada;
        const response = await fetch(url);
        var data = await response.json();
        console.log(data);
        this.setState({ productosVendidos: data });
        this.ListarCategoriasHistorico();
    }

    async ListarCategoriasHistorico() {
        var productos = this.state.productosVendidos;

        for (var i = 0; i < productos.length; i++) {
            var url = "http://localhost:61063/api/Subfuncions/" + productos[i]['codigoSubFn'];
            const response = await fetch(url);
            var data = await response.json();
            productos[i]['categoriaProd'] = data['descSubFn'];
        }
        
        this.setState({ productosVendidos: productos, categorias: this.RemoverDuplicados(this.CategoriasBruto(productos)) });
    }

    Procesar() {
        if (this.state.filtroPorFecha) {
            this.TraerDatosPorFecha();
        }
        else {
            this.ListarVentasDelDia()
        }
    }

    render() {
        return (
            <div id="PorDepartamentos">
                <div className="darBorde" id="opciones">
                    <h1>Total vendido</h1>
                    <p>
                        <input type="radio" checked name="tipoBusqueda" value="tipoBusqueda" onClick={() => { this.NoFiltrar() }} /> Venta acumulada
                        <input type="radio" name="tipoBusqueda" value="tipoBusqueda" onClick={() => { this.Filtrar() }} /> Venta historica
                    </p>
                    <p>
                        {
                            this.state.filtroPorFecha ? (<div><input type="date" id="fecha" /></div>) : (<div></div>)//agregar el input date
                        }
                    </p>
                    <input type="button" className="btn btn-primary" onClick={() => { this.Procesar() }} value="Procesar" />
                </div>
                <div className="darBorde">
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
                <table className="tablaNormal">
                    <tr>
                        <th className="tablaNormal">N°</th>
                        <th className="tablaNormal">Medio de pago</th>
                        <th className="tablaNormal">Monto total</th>
                    </tr>

                    
                </table>
                    <p></p>
                    
                <Link to="/menu"><button className="btn btn-secondary">Cerrar</button></Link>
                </div>
            </div>
        );
    }
}
