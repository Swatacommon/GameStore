import React, { Component } from 'react';
import '../../auth.css';
import { Redirect } from 'react-router-dom';

export class Auth extends Component {
    static displayName = Auth.name;

    constructor(props) {
        super(props);
        this.state = { games: [], email: '', password: '', loading: true, logged: false, errorMessage: '' };
    }

    componentWillMount() {
        if (sessionStorage.getItem('tokenKey')) {
            this.setState({ logged: true });
        }
    }

    render() {
        if (this.state.logged == false) {
            return (
                <div className="authForm">
                    <div className="background-image"></div>
                    <form onSubmit={this.SignIn.bind(this)}>
                        <div id="loginForm">
                            <label className="errorMessage">{this.state.errorMessage}</label>
                            <div>
                                <label>Email</label><br />
                                <input type="email" placeholder="Email" onChange={this.onChangeEmail.bind(this)} id="emailLogin" /> <br /><br />
                            </div>
                            <div>
                                <label>Password</label><br />
                                <input type="password" placeholder="Password" onChange={this.onChangePassword.bind(this)} id="passwordLogin" />
                            </div>
                            <div>
                                <br /><br />
                                <input type="submit" id="submitLogin" value="Login" />
                                <br />
                                <a href="/">Back</a>
                            </div>
                        </div>
                    </form>
                </div>
            );
        } else {
            return <Redirect to="/" />
        }
    }

    onChangeEmail(e) {
        var val = e.target.value;
        this.setState({ email: val });
    }

    onChangePassword(e) {
        var val = e.target.value;
        this.setState({ password: val });
    }

    async SignIn(e) {
        e.preventDefault();
        // получаем данные формы и фомируем объект для отправки
        const formData = new FormData();
        formData.append("grant_type", "password");
        formData.append("email", this.state.email);
        formData.append("password", this.state.password);
        console.log('email: ', this.state.email);
        console.log('password: ', this.state.password);
        const response = await fetch("/accesstoken", {
            method: "POST",
            headers: { "Accept": "application/json" },
            body: formData
        });

        const data = await response.json();
        let user = JSON.parse(data);

        // если запрос прошел нормально
        if (response.ok === true) {
            // сохраняем в хранилище sessionStorage токен доступа
            sessionStorage.setItem('tokenKey', user.access_token);
            this.setState({ logged: true });
        }
        if (response.status === 400) {
            console.log('Bad request');
            // если произошла ошибка, из errorText получаем текст ошибки
            setTimeout(() => { this.setState({ errorMessage: "" }); }, 2000);
            this.setState({ errorMessage: "Invalid Email or Password" });
        }
    }
}
