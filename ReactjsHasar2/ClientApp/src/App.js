import React, { Component } from 'react';
import { Route } from 'react-router';


import { Keyboard } from './components/Keyboard';
import { Cabecera } from './components/Cebecera';
import { MenuPrincipal } from './components/MenuPrincipal';
import { TotalVendido } from './components/TotalVendido';
import { CierreCaja } from './components/CierreCaja';

export default class App extends Component {
  displayName = App.name

  render() {
      return (
          <div>
                  <Route path="/menu" component={MenuPrincipal}> </Route>
                  <Route path="/facturar" component={Keyboard} />
                  <Route path="/total" component={TotalVendido} />
                  <Route path="/cierreCaja" component={CierreCaja} />
          </div>
    );
  }
}
