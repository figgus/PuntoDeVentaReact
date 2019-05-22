import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Arqueo.css';

export class Arqueo extends Component {
    displayName = Arqueo.name;

    constructor(props) {
        super(props);
        this.state = {
            ventas: [],
            operadores: [],
            fecha: new Date().toLocaleDateString(),
            codigoOperador:null,
        };
        this.TraerOperadores();
        this.TraerVentas();
        
    }

    componentDidMount() {
        this.FechaDefault();
    }

    async TraerOperadores() {
        const url = "http://localhost:61063/api/Operadors";
        const response = await fetch(url);
        var data = await response.json();
        //console.log(data);

        this.setState({ operadores: data, codigoOperador: data[0].codigoOperador });
    }

    async TraerVentas() {
       
        var fecha = this.state.fecha;
        const codigoOperador = this.state.codigoOperador;
        const url = "http://localhost:61063/api/Historico_rendicion?fecha=" + fecha + "&codigoOperador=" + codigoOperador;
        console.log(url);
        const response = await fetch(url);
        var data = await response.json();
        this.setState({ ventas: data });
    }

    CambiarOperador() {
        var codigoFiltro = document.getElementById('codigoOperador').value;
        codigoFiltro = codigoFiltro.substr(0, codigoFiltro.indexOf('-'));
        this.setState({ codigoOperador: codigoFiltro });
    }


    CambiarFechaFiltro() {
        var fecha = document.getElementById('fecha').value;
        
        this.setState({ fecha: fecha });
    }

    FechaDefault() {
        var date = new Date();

        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear(),
            hour = date.getHours(),
            min = date.getMinutes();

        month = (month < 10 ? "0" : "") + month;
        day = (day < 10 ? "0" : "") + day;
        hour = (hour < 10 ? "0" : "") + hour;
        min = (min < 10 ? "0" : "") + min;

        var today = year + "-" + month + "-" + day,
            displayTime = hour + ":" + min;

        document.getElementById('fecha').value = today;
    }

    GetMontoTotal() {
        var ventas = this.state.ventas;
        var cont = 0;
        ventas.forEach(function (element) {
            cont = cont + element.monto;
        });
        return cont;
    }

    GetRendidoTotal() {
        var ventas = this.state.ventas;
        var cont = 0;
        ventas.forEach(function (element) {
            cont = cont + element.rendido;
        });
        return cont;
    }

    GetRecibidoTotal() {
        var ventas = this.state.ventas;
        var cont = 0;
        ventas.forEach(function (element) {
            cont = cont + element.recibido;
        });
        return cont;
    }

    GetRetiradoTotal() {
        var ventas = this.state.ventas;
        var cont = 0;
        ventas.forEach(function (element) {
            cont = cont + element.retirado;
        });
        return cont;
    }

    GetDiferenciaTotal() {
        var ventas = this.state.ventas;
        var cont = 0;
        ventas.forEach(function (element) {
            cont = cont + element.diferencia;
        });
        return cont;
    }

    render() {
        return (
            <div className="darSeparacion">
                <h1>Recaudacion por operador</h1>
                <div className="darSeparacion">
                <p>Seleccione un operador
                    <select onChange={() => { this.CambiarOperador() }} id="codigoOperador" >
                    {
                        this.state.operadores.map((item, index) => (
                            <option key={index}> {item.codigoOperador + ' - ' + item.apellido} </option>
                        ))
                    }
                     </select>
                    <p className="aDerecha">Zeta/Fecha
                        <input onChange={() => { this.CambiarFechaFiltro() }} defaultValue={this.state.fecha} id="fecha" type="date" />
                        <button onClick={() => { this.TraerVentas() }} className="btn btn-primary">Procesar</button>
                    </p>
                </p>
                
                <table className="tablaNormal">
                    <thead>
                        <th className="tablaNormal">Descripcion</th>
                        <th className="tablaNormal">Cantidad</th>
                        <th className="tablaNormal">Monto</th>
                        <th className="tablaNormal">Rendido</th>
                        <th className="tablaNormal">Recibido</th>
                        <th className="tablaNormal">Retirado</th>
                        <th className="tablaNormal">Diferencia</th>
                    </thead>
                        {
                        this.state.ventas.map((item, index) => (
                            <tr>
                                <td className="tablaNormal"> {item.descripcion} </td>

                                <td className="tablaNormal">  {item.cantidad}</td>
                                <td className="tablaNormal"> {item.monto}</td>
                                <td className="tablaNormal">  {item.rendido}</td>
                                <td className="tablaNormal">{item.recibido} </td>
                                <td className="tablaNormal">  {item.retirado}</td>
                                <td className="tablaNormal">  {item.diferencia}</td>
                            </tr>
                            ))
                            

                }
                        < tr >
                            <td className="tablaNormal"></td>
                            <td className="tablaNormal"></td>
                            <td className="tablaNormal"></td>
                            <td className="tablaNormal"></td>
                            <td className="tablaNormal"></td>
                            <td className="tablaNormal"></td>
                            <td className="tablaNormal"></td>
                        </tr>
                        < tr >
                            <td className="tablaNormal">Totales</td>
                            <td className="tablaNormal"></td>
                            <td className="tablaNormal">{this.GetMontoTotal()}</td>
                            <td className="tablaNormal">{this.GetRendidoTotal()}</td>
                            <td className="tablaNormal">{this.GetRecibidoTotal()}</td>
                            <td className="tablaNormal">{this.GetRetiradoTotal()}</td>
                            <td className="tablaNormal">{this.GetDiferenciaTotal()}</td>
                        </tr>
                    </table>
                </div>
                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
