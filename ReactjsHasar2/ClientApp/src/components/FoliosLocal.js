﻿import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { FinDia } from './FinDia';

export class FoliosLocal extends Component {
    displayName = FoliosLocal.name

    constructor() {
        super();
        this.state = {
            ultimoAsignado: 0,
            restantes: 0,
            total: 0,
            numVentas: 0,
            rangosIngreso: [],

            desde: 0,
            hasta: 0,
            //folios:[],
        };
        this.TraerUltTicket();
        this.TraerRestantes();
        this.foliosTotal();
        this.TraerNumeroVentas();
        //this.TraerFolios();
        this.TraerRangos();
    }

    async SolicitarFolios() {
        var cantidad = document.getElementById('cantidad').value;
        if (!isNaN(cantidad) && !cantidad==null) {
            alert('El la cantidad ingresada no es valida');
        }
        else
        {
            const url = 'http://localhost:49929/solicitudFolios?cant=' + cantidad + '&idSucursal=1';
            console.log(url);
            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },

            })
            //console.log(response);
            var data = await response.json();
            console.log(data);
            var min = 0;
            var max = 0;
            data.forEach(function (currentValue, index, array) {
                if (currentValue.numFolio > max) {
                    max = currentValue.numFolio;
                }

                const response = fetch('http://localhost:61063/api/FoliosLocals', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        numFolio: currentValue.numFolio,
                        descripcion: currentValue.descripcion,
                        estaDisponible: 1,

                    })
                });
            });
            min = max - cantidad;
            console.log(max);
            console.log(min);
            this.RegistrarSolicitudFolios(cantidad, min, max);
        }
    }

    RegistrarSolicitudFolios(cantidad, min, max) {
        const response = fetch('http://localhost:61063/api/Solicituds', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                cantidad: cantidad,
                primerFolio: min,
                ultimoFolio: max,
            })
        });
    }


    async TraerUltTicket() {
        const url = "http://localhost:61063/getUltimoAsignado";
        const response = await fetch(url);
        const data = await response.json();

        this.setState({ ultimoAsignado: data.ultimoAsignado });
    }

    async TraerRestantes() {
        const url = "http://localhost:61063/getRestantes";
        const response = await fetch(url);
        const data = await response.json();

        this.setState({ restantes: data.restantes });
    }

    async foliosTotal() {
        const url = "http://localhost:61063/getTotales";
        const response = await fetch(url);
        const data = await response.json();

        this.setState({ total: data.total });
    }

    async TraerNumeroVentas() {
        const url = "http://localhost:61063/getNumeroVentas";//operacionesFoliosLocal
        const response = await fetch(url);
        const data = await response.json();

        this.setState({ numVentas: data.numVentas });
    }

    async TraerFolios() {
        const url = "http://localhost:61063/api/FoliosLocals";
        const response = await fetch(url);
        const data = await response.json();

        this.setState({ folios: data });
        //console.log(this.state.folios);
    }

    async TraerRangos() {
        const url = "http://localhost:61063/api/Solicituds";
        const response = await fetch(url);
        const data = await response.json();

        this.setState({ rangosIngreso: data });
        console.log(this.state.rangosIngreso);
    }

    async TraerDatosAyer() {
        const url = "http://localhost:61063/api/Solicituds";
        const response = await fetch(url);
        const data = await response.json();

        this.setState({ rangosIngreso: data });
    }

    TraerRango() {
        var min = this.state.desde;
        var max = this.state.hasta;

        if (min === 0 && max === 0) {
            return 'el dia anterior no se usaron folios';
        }
        else {
            return 'se usaron los folios desde ' + min + ' hasta ' + max;
        }
    }

    render() {
        return (
            <div>
                <h1>Panel de folios locales</h1>
                <div>
                    <p> Solicitar folios </p>
                    <p> Cantidad  <input id="cantidad" type="number" /> <button onClick={() => { this.SolicitarFolios() }}>Solicitar</button> </p>
                </div>

                <div>
                    <p>Ultimo folio asignado {this.state.ultimoAsignado}</p>
                    <p>Cantidad de tickets restantes {this.state.restantes} </p>
                    <p>Total de folios solicitados {this.state.total} </p>
                    <p>Numero de folios vendidos {this.state.numVentas}</p>
                    <p> Rangos de folios </p>
                    <table className="tablaNormal">
                        <thead>
                            <th className="tablaNormal">N°</th>
                            <th className="tablaNormal">Primer folio</th>
                            <th className="tablaNormal"> Ultimo folio </th>
                            <th className="tablaNormal"> Cantidad </th>
                            <th className="tablaNormal"> Fecha de solicitud</th>
                        </thead>

                        {
                            this.state.rangosIngreso.map(function (item, i) {
                                return <tr key={(i + 1)}>
                                    <td className="tablaNormal">{(i + 1)} </td>
                                    <td className="tablaNormal">{item.primerFolio + 1} </td>
                                    <td className="tablaNormal">{item.ultimoFolio}</td>
                                    <td className="tablaNormal"> {item.cantidad} </td>
                                    <td className="tablaNormal"> {item.fecha} </td>
                                </tr>
                            })
                        }
                    </table>
                    <div>
                        <h1>Inicio dia</h1>
                        <p>{this.TraerRango()}</p>
                    </div>
                    <FinDia></FinDia>
                </div>

                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
