import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { GamesCatalog } from './components/GamesCatalog/GamesCatalog';
import { Counter } from './components/Counter';
import { Auth } from './components/Auth/Auth';
import { NotFound } from './components/NotFound';
import { NavBar } from './components/NavBar';
import { Profile } from './components/Profile/Profile';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Switch>
                    <Route exact path='/authorization' component={LoginContainer} />
                    <Route path='/' component={DefaultContainer} />
                    <Route component={NotFound} />
                </Switch>
            </Layout>
        );
    }
}

class LoginContainer extends Component {
    render() {
        return (
            <div className="container">
                <Route exact path='/authorization' component={Auth} />
            </div>
        );
    }
}

class DefaultContainer extends Component {
    render() {
        return (
            <div className="container">
                <NavBar />
                <Route exact path='/' component={Home} />
                <Route path='/counter' component={Counter} />
                <Route path='/catalog' component={GamesCatalog} />
                <Route path='/profile' component={Profile} />
            </div>
        );
    }
}