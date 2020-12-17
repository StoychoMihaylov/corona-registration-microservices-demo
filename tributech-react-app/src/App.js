import React, { Component } from 'react'
import { Route } from 'react-router'
import { NotificationContainer } from 'react-notifications'
import { Layout } from './screens/Layout/Layout'
import { Registration } from './screens/Registration/Registration'
import NotificationService from './components/NotificationService/NotificationService'

import 'react-notifications/lib/notifications.css'

export default class App extends Component {
  render () {
    return (
      <Layout>
        <NotificationContainer/>
        <NotificationService />
        <Route exact path='/' component={Registration} />
      </Layout>
    );
  }
}
