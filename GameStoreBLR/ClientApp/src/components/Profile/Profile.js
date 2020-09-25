import React, { Component } from 'react';
import '../../auth.css';
import { Redirect } from 'react-router-dom';

export class Profile extends Component {
    static displayName = Profile.name;

    constructor(props) {
        super(props);
        this.state = { games: [], email: '', password: '', loading: true, logged: true };
        this.logOut = this.logOut.bind(this);
    }

    componentWillMount() {
        this.getUserInfo();
    }

    render() {
        if (this.state.logged == true) {
            return (
                <div>
                    <p>PROFILE</p>
                    <button onClick={this.logOut}>Logout</button>
                </div>
            );
        } else {
            return <Redirect to="/authorization" />
        }
    }

    logOut() {
        sessionStorage.removeItem("tokenKey");
        this.setState({ logged: false });
    }

    async getUserInfo(e) {
        const token = sessionStorage.getItem("tokenKey");

        const response = await fetch("/api/users", {
            method: "GET",
            headers: {
                "Accept": "application/json",
                "Authorization": "Bearer " + token  // передача токена в заголовке
            }
        });
        if (response.ok === true) {

            const data = await response.json();
        }
        else {
            this.setState({ logged: false })
            sessionStorage.removeItem("tokenKey");
        }
    }
}
