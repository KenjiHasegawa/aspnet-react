import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchProduct } from './components/FetchProduct';
import { FetchGuestCheck } from './components/FetchGuestCheck';

import './custom.scss'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/product' component={FetchProduct} />
                <Route path='/guest-check' component={FetchGuestCheck} />
            </Layout>
        );
    }
}
