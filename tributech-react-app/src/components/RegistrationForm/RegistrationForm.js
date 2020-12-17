import React from 'react'
import axios from 'axios'
import { api } from '../../constants/endpoints'
import { NotificationManager } from 'react-notifications'

import './RegistrationForm.css'

class RegistrationForm extends React.PureComponent {
    constructor(props) {
        super(props)

        this.state = {
            firstName: "",
            lastName: "",
            email: "",
            age: 0,
            symptoms: ""
        }
    }

    requestAPI(registrationForm) {
       return axios.post(api.webGateway + 'applicant/registration', registrationForm , {
            headers: {
                'Access-Control-Allow-Origin': '*'
            }
        })
        .then((response => {
            return response
        }))
        .catch((err) => {
            console.error(err)
        })
    }

    handleSubmit() {

        let registrationForm = {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            email: this.state.email,
            age: 0,
            symptoms: this.state.symptoms
        }

        this.requestAPI(registrationForm)
            .then((response) => {
                if (response.status === 202) {
                    console.log("here")
                    NotificationManager.info('Processing your data...', '', 4000)
                }
            })

        this.resetTheForm()
    }

    resetTheForm() {
        this.setState({
            firstName: "",
            lastName: "",
            email: "",
            age: 0,
            symptoms: ""
        })
    }

    render () {
        return (
            <div className="registration-form-container">
                <table>
                    <tbody>
                        <tr>
                            <th><label>First Name:</label></th>
                            <td>
                                <input
                                    type="text"
                                    placeholder="First Name..."
                                    name="first name"
                                    value={this.state.firstName}
                                    onChange={(e) => this.setState({firstName: e.target.value})}
                                    />
                            </td>
                        </tr>
                        <tr>
                            <th><label>Last Name:</label></th>
                            <td>
                                <input
                                    type="text"
                                    placeholder="Last Name..."
                                    name="last name"
                                    value={this.state.lastName}
                                    onChange={(e) => this.setState({lastName: e.target.value})}
                                    />
                            </td>
                        </tr>
                        <tr>
                            <th><label>Email:</label></th>
                            <td>
                                <input
                                    type="text"
                                    placeholder="john@gmail.com..."
                                    name="email"
                                    value={this.state.email}
                                    onChange={(e) => this.setState({email: e.target.value})}
                                    />
                            </td>
                        </tr>
                        <tr>
                            <th><label>Age:</label></th>
                            <td>
                                <input
                                    type="text"
                                    placeholder="type your age..."
                                    name="age"
                                    value={this.state.age}
                                    onChange={(e) => this.setState({age: e.target.value})}
                                    />
                            </td>
                        </tr>
                        <tr>
                            <th><label>Symptoms:</label></th>
                            <td>
                                <textarea
                                    placeholder="type your complaints..."
                                    rows="3"
                                    value={this.state.symptoms}
                                    onChange={(e) => this.setState({symptoms: e.target.value})}
                                />
                            </td>
                        </tr>
                        <tr>
                            <th></th>
                            <td>
                                <button
                                    className="submit-bttn"
                                    onClick={() => this.handleSubmit()}
                                >Submit
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}

export default RegistrationForm