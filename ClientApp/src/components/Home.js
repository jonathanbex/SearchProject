import React, { Component } from 'react';
import { Search } from '../components/Search';
export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <Search />
            </div>
        );
    }
}
