import React, { Component } from 'react';
import '../../auth.css';
import { Redirect } from 'react-router-dom';

export class Auth extends Component {
    static displayName = Auth.name;

    constructor(props) {
        super(props);
        this.state = {
            games: [], login: '', email: '', password: '', loading: true,
            logged: false, errorMessage: '', registration: "login no",
            authButton: "Login", regButton: "Registration"
        };
        this.signIn = this.SignIn.bind(this);
        this.signUp = this.SignUp.bind(this);
    }

    componentWillMount() {
        const token = sessionStorage.getItem('tokenKey');
        console.log(token);
        if (token === undefined || token === null) {
            this.setState({ logged: false })
        } else {
            this.setState({ logged: true })
        }
    }

    render() {
        if (this.state.logged !== false) {
                return <Redirect to="/" />
        }
        return (
            <div className="authForm">
                <div className="background-image"></div>
                <form onSubmit={this.state.registration === 'login no' ? this.signIn : this.signUp}>
                    <div id="loginForm">
                        <label className="errorMessage">{this.state.errorMessage}</label>
                        <div className={this.state.registration}>
                            <label>Login</label><br />
                            <input type="text" placeholder="Login" onChange={this.onChangeLogin.bind(this)} id="inputLogin" /> <br /><br />
                        </div>
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
                            <input type="submit" id="submitLogin" value={this.state.authButton} />
                            <br />
                            <div className="authFormBottomMenu">
                                <a href="/">Back</a>
                                <input id="registerButton" type="button" value={this.state.regButton} onClick={this.onRegistration.bind(this)} />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        );
    }

    onRegistration(e) {
        this.setState({
            registration: this.state.registration === 'login' ? 'login no' : 'login',
            regButton: this.state.registration === 'login' ? 'Registration' : 'Login',
            authButton: this.state.registration === 'login' ? 'Login' : 'Registration',
        });
    }

    onChangeLogin(e) {
        var val = e.target.value;
        this.setState({ login: val });
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
        const response = await fetch("/tokens", {
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

    async SignUp(e) {
        e.preventDefault();
        // получаем данные формы и фомируем объект для отправки
        const formData = new FormData();
        formData.append("grant_type", "password");
        formData.append("email", this.state.email);
        formData.append("login", this.state.login);
        formData.append("password", this.state.password);
        console.log('login: ', this.state.login);
        console.log('email: ', this.state.email);
        console.log('password: ', this.state.password);
        const response = await fetch("/signup", {
            method: "POST",
            headers: { "Accept": "application/json" },
            body: formData
        });

        // если запрос прошел нормально
        if (response.ok === true) {
            // сохраняем в хранилище sessionStorage токен доступа
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
