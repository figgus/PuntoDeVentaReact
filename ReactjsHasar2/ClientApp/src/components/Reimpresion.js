import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Reimpresion extends Component {
    displayName = Reimpresion.name

    constructor() {
        super();
        this.state = {

        }
    }

    componentDidMount() {
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.innerHTML = 'Cargar();';
        document.body.appendChild(script);
    }

    ImprimirBoleta(listaProd) {//recibe una lista de objectos tipo plu(producto)
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.innerHTML = 'print(' + JSON.stringify(listaProd) + ');';
        document.body.appendChild(script);
    }

    async TraerVentas(numFolio) {//traeTodos los registros de hist_fn y los filtra por numero de folio
        
        const url = "http://localhost:61063/api/hist_fn";
        const response = await fetch(url);
        const data = await response.json();
        return data.filter(function (el) {
            return el.numeroFolio === numFolio;
        });
       
    }

    async TraerProductosPorFolio(numFolio) {
        const ventas = await this.TraerVentas(numFolio);
        var listaProductos = [];
        //console.log(ventas);
        for (var i = 0; i < ventas.length; i++) {
            const CodProdActual = ventas[i].codPLU
            const url = "http://localhost:61063/api/plu/" + CodProdActual;
            const response = await fetch(url);
            const data = await response.json();
            listaProductos.push(data);
        }
        return listaProductos;
        
    }

    async IngresarFolio() {//se ejecutar al clickear numFolio
        const folioBuscar = Number(document.getElementById('numFolio').value);
        const productos = await this.TraerProductosPorFolio(folioBuscar);
        if (productos == null || productos.length===0) {
            alert('Numero de folio no valido');
        }
        else {
            this.ImprimirBoleta(productos);
        }
    }


    render() {
        return (
            <div>
                <p> Ingrese el numero de folio a imprimir  <input id="numFolio" type="number" />  <button onClick={() => { this.IngresarFolio() }}>Imprimir</button></p>

                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
