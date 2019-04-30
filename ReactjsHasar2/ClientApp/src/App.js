import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import { Keyboard } from './components/Keyboard';
import { Cabecera } from './components/Cebecera';
import { MenuPrincipal } from './components/MenuPrincipal';
import { TotalVendio, TotalVendido } from './components/TotalVendido';

export default class App extends Component {
  displayName = App.name

  render() {
      return (
          <div>
              <Route path="/Menu" component={MenuPrincipal} />
              <Route path="/facturar" component={Keyboard} />
              <Route path="/total" component={TotalVendido} />
          </div>
    );
  }
}
