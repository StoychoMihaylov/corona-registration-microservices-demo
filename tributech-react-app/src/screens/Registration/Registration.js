import React, { Component } from 'react';
import RegistrationForm from '../../components/RegistrationForm/RegistrationForm'
import './Registration.css'

export class Registration extends Component {
  render () {
    return (
      <div className="registration-container">

        <div>
          <img className="covid-logo-img" src={process.env.PUBLIC_URL + 'covid-logo.jpg'} alt="" />
        </div>

        <span>
          <h1>Covid infection registration</h1>
          <i>Powered by Tributech</i>
          <img className="tributech-logo-img" src={process.env.PUBLIC_URL + 'tributech-logo.jpg'} alt="" />
        </span>

        <RegistrationForm />
      </div>
    );
  }
}
