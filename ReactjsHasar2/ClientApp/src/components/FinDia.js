import React, { Component } from 'react';
import './NavMenu.css';

export class FinDia extends Component {
    displayName = FinDia.name

    constructor() {
        super();
        this.state = {
            foliosUsados: [],
            min: 0,
            max: 0,
        };
        this.TraerFolios();
        this.TraerFoliosUsados();
    }

    async TraerFoliosUsados() {
        const url = "http://localhost:61063/OperacionesFoliosLocales/getFoliosDia";
        const response = await fetch(url);
        const data = await response.json();

        var min = 0;
        var max = 0;
        data.forEach(function (item, i) {
            if (item.numFolio > max) {
                max = item.numFolio;
            }
        });
        console.log(min);
        console.log(max);
        min = max - data.length;
        this.setState({ foliosUsados: data, max: max, min: min });
    }

    async TraerFolios() {
        const url = "http://localhost:61063/OperacionesFoliosLocales/getFoliosDia";
        const response = await fetch(url);
        const data = await response.json();

        this.setState({ foliosUsados: data });
    }

    foliosUsadosHoy() {
        const minHoy = this.state.min;
        const maxHoy = this.state.max;
        if (minHoy === 0 && maxHoy === 0) {
            return 'Hoy no se han realizado ventas';
        }
        else {
            return 'Los folios usados el dia de hoy fueron desde '+this.state.min+' hasta '+this.state.max;
        }
    }
    render() {
        return (
            <div>
                <h1>Fin dia </h1>
                <p> {this.foliosUsadosHoy()}</p>

            </div>
        );
    }
}
