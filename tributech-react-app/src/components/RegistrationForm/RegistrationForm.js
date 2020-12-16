import React from 'react'
import './RegistrationForm.css'

class RegistrationForm extends React.PureComponent {
    constructor(props) {
        super(props)

        this.state = {

        }
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
                                    name="first name" />
                            </td>
                        </tr>
                        <tr>
                            <th><label>Last Name:</label></th>
                            <td>
                                <input
                                    type="text"
                                    placeholder="Last Name..."
                                    name="last name" />
                            </td>
                        </tr>
                        <tr>
                            <th><label>Email:</label></th>
                            <td>
                                <input
                                    type="text"
                                    placeholder="joghn@gmail.com..."
                                    name="email" />
                            </td>
                        </tr>
                        <tr>
                            <th><label>Age:</label></th>
                            <td>
                                <input
                                    type="text"
                                    placeholder="type your age..."
                                    name="age" />
                            </td>
                        </tr>
                        <tr>
                            <th><label>Syndromes:</label></th>
                            <td>
                                <textarea
                                    placeholder="type your complaints..."
                                    rows="3"
                                />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}

export default RegistrationForm