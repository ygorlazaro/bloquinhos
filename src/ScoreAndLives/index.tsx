import * as React from 'react';
import Scores from '../Scores'
import Lives from '../Lives'

interface IProps {
    lives: number;
    score: number;
}

class ScoreAndLives extends React.Component<IProps>{

    render(): JSX.Element {
        const { score, lives } = this.props;

        return <div>
            <Scores score={score} />
            <Lives lives={lives} />
        </div>
    }
};

export default ScoreAndLives;