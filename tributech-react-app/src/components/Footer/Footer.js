import React from 'react'
import './Footer.css'

class Footer extends React.PureComponent {
    render() {
        return (
            <footer>
                <img className="footer-img" src={process.env.PUBLIC_URL + 'tributech-footer-img.jpg'}  alt="" />
            </footer>
        )
    }
}

export default Footer