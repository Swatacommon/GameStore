import React, { Component } from 'react';
export class GameItem extends Component {
    constructor(props) {
        super(props);
        this.state = { image: null, loading: false };

        this.addToCard = this.addToCard.bind(this);
    }

    addToCard(e) {
        console.log(e);
        alert(e);
    }

    static renderGameItem(game, addToCard) {
        let imgUrl = 'http://localhost:5329/api/images/' + game.gameImages[0].imageNameNavigation.name + game.gameImages[0].imageNameNavigation.format;
        return (
            <div className="gameCard">
                <input type="button" value="Add to cart" key={game.id} className="orderButton" onClick={addToCard} />
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
            : GameItem.renderGameItem(this.props.game, this.addToCard);

        return (
            <div>
                {contents}
            </div>
        );
    }
}