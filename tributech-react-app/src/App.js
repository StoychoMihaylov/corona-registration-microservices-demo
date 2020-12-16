import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './screens/Layout/Layout';
import { Registration } from './screens/Registration/Registration';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Registration} />
      </Layout>
    );
  }
}
