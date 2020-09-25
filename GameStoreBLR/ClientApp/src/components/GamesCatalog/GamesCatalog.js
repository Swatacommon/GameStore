import React, { Component } from 'react';
import "../../gamesCatalog.css";
import { GameItem } from "./GameItem.js";

export class GamesCatalog extends Component {
    static displayName = GamesCatalog.name;

    constructor(props) {
        super(props);
        this.state = { games: [], loading: true };
    }

    componentDidMount() {
        this.GamesCatalogData();
    }

    static renderGamesCatalogTable(games) {
        return (
            <div className="gameCatalog" >
                {games.map(game => {
                    return <GameItem key={game.id} game={game} />
                })}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GamesCatalog.renderGamesCatalogTable(this.state.games);

        return (
            <div>
                <h1 id="tabelLabel">Games Catalog</h1>
                {contents}
            </div>
        );
    }

    async GamesCatalogData() {
        const token = sessionStorage.getItem('tokenKey');
        const response = await fetch('api/games', {
            method: "GET",
            headers: {
                "Accept": "application/json",
                "Authorization": "Bearer " + token
            }
        });
        if (response.ok === true) {
            const data = await response.json();
            console.log(token);
            this.setState({ games: data, loading: false });
        } else {
            console.log(response.statusText);
        }
    }
}
