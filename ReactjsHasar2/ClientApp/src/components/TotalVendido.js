import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { LinkContainer } from 'react-router-bootstrap';

export class TotalVendido extends Component {
    displayName = TotalVendido.name

    constructor() {
        super();
        this.state = {
            productosVendidos: [] 
        };
        this.ListarVentasDelDia();
    }

    //async componentDidMount() {
    //    const url = "http://localhost:61063/api/Hist_plu";
    //    const response = await fetch(url);
    //    const data = await response.json();
    //    this.setState({ productosVendidos: data });
    //    console.log(data);
    //}
    async ListarVentasDelDia() {
        
        const url = "http://localhost:61063/api/Hist_plu";
        const response = await fetch(url);
        //console.log(response);
        var data = await response.json();

        this.setState({ productosVendidos: data });
        console.log(this.state.productosVendidos);
    }


    render() {
        return (
            <div>
                <h1>Total vendido</h1>
                <table>
                    <thead>
                        <tr>
                            <td>Descripcion</td>
                            <td>Cantidad</td>
                            <td>Monto</td>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.productosVendidos.map(function (item, i) {
                                //console.log(item[i]);
                                return <tr key={i}>
                                    <td>{i + 1}</td>
                                    
                                    <td>  </td>
                                </tr>
                            })
                        }

                    </tbody>
                </table>
                <button onClick={() => this.ListarVentasDelDia()}>click</button>
            </div>
        );
    }
}
