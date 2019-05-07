import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Arqueo extends Component {
    displayName = Arqueo.name

    constructor(props) {
        super(props);
        this.state = { };
    }

    

    render() {
        return (
            <div>
                <h1>Arqueo</h1>


                <Link to="/menu"> <button className="btn btn-secondary">Cerrar</button></Link>
            </div>
        );
    }
}
