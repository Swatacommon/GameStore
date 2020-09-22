import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Router } from 'reactstrap';
import { Link } from 'react-router-dom';
import "../custom.css"


export class NavBar extends Component {
    static displayName = NavBar.name;

    constructor(props) {
        super(props);

        this.state = {
            collapsed: true,
            isAuthorized: false
        };
    }

    componentWillMount() {
        const token = sessionStorage.getItem('tokenKey');
        console.log(token);
        if (token === undefined || token === null) {
            this.setState({ isAuthorized: false })
        } else {
            this.setState({ isAuthorized: true })
        }
    }

    render() {
        return (
            <header className="NavBar">
                <Link to="/" className="NavItem">Main</Link>
                <Link to="/counter" className="NavItem">Counter</Link>
                <Link to="/catalog" className="NavItem">Catalog</Link>
                {this.state.isAuthorized === false
                    ? <Link to="/authorization" className="NavItem">Sign In/Out</Link>
                    : <Link to="/profile" className="NavItem">Profile</Link>
                }
            </header>
        );
    }
}
