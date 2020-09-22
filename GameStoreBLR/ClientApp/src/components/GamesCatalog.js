import React, { Component } from 'react';
import "../gamesCatalog.css"

class GameItem extends Component {
    constructor(props) {
        super(props);
        this.state = { image: null, loading: false };
    }

    static renderGameItem(game) {
        let imgUrl = 'http://localhost:5329/api/images/' + game.gameImages[0].imageNameNavigation.name + game.gameImages[0].imageNameNavigation.format;
        return (
            <div className="gameCard">
                <img src={imgUrl} className="gameCardImage" />
                <div className="gameCardInfo">
                    <div className="gameCardInfoShadow">
                        <p>{game.name}</p>
                        <p className="gameCardInfoPrice">{game.price}</p>
                    </div>
                </div>
            </div>
        )
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GameItem.renderGameItem(this.props.game);

        return (
            <div>
                {contents}
            </div>
        );
    }
}

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
