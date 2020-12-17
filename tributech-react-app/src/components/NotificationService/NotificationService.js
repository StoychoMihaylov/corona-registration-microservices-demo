import React from 'react'
import { api } from '../../constants/endpoints'
import { HubConnectionBuilder } from '@microsoft/signalr'
import { NotificationManager } from 'react-notifications'

class NotificationService extends React.Component {

    componentDidMount() {
        this.StartConnection()
    }

    StartConnection() {
        const connection = new HubConnectionBuilder()
            .withUrl(api.notificationAPI + 'hubs/web-event-notification')
            .withAutomaticReconnect([0, 1000, 2000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000])
            .build()

        connection.start()
            .then(() => {
                connection.on('ReceiveNotificationMessage', message => {
                    console.log(message)
                    NotificationManager.success(message, '', 3000)
                })
            })
            .catch(err => {
                console.log('Connection failed: ', err)
            })
    }

    render() {
        return null
     }
}

export default NotificationService
