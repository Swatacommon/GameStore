import React, { Component } from 'react';
import '../auth.css';

export class Auth extends Component {
    static displayName = Auth.name;

    constructor(props) {
        super(props);
        this.state = { games: [], email: '', password: '', loading: true, name: 'noname' };
    }



    render() {
        return (
            <div className="authForm">
                <div className="background-image"></div>
                <form onSubmit={this.SignIn.bind(this)}>
                    <div id="loginForm">
                        <div>
                            <label>Email</label><br />
                            <input type="email" onChange={this.onChangeEmail.bind(this)} id="emailLogin" /> <br /><br />
                        </div>
                        <div>
                            <label>Password</label><br />
                            <input type="password" onChange={this.onChangePassword.bind(this)} id="passwordLogin" />
                        </div>
                        <div>
                            <br /><br />
                            <input type="submit" id="submitLogin" value="Login" />
                        </div>
                    </div>
                    <div id="userInfo">
                        <input type="button" value="Log out" id="logOut" onClick={this.LogOut.bind(this)} />
                    </div>
                </form>
            </div>
        );
    }

    onChangeEmail(e) {
        var val = e.target.value;
        this.setState({ email: val });
    }

    onChangePassword(e) {
        var val = e.target.value;
        this.setState({ password: val });
    }

    LogOut(e) {
        sessionStorage.removeItem('tokenKey');
        window.location.reload();
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
        console.log("Data: ", user.access_token);
        console.log("Data.access_token: ", user.email);
        // если запрос прошел нормально
        if (response.ok === true) {

            // изменяем содержимое и видимость блоков на 

            // сохраняем в хранилище sessionStorage токен доступа
            sessionStorage.setItem('tokenKey', user.access_token);
            this.setState({ name: user.email });
            window.location.reload();
        }
        else {
            // если произошла ошибка, из errorText получаем текст ошибки
            console.log("Error: ", response.status, data.errorText);
        }
    }
}
