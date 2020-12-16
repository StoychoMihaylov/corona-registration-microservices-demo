import React, { Component } from 'react';
import { Container } from 'reactstrap';
import Footer from '../../components/Footer/Footer'

import './Layout.css'

export class Layout extends Component {
  render () {
    return (
      <div>
        <Container>
          {this.props.children}
        </Container>
        <Footer />
      </div>
    );
  }
}
