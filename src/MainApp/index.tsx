import * as React from "react";
import ChoosedColor from "../ChoosedColor";
import GridTable from "../GridTable";
import ScoreAndLives from "../ScoreAndLives";

interface IState {
    lives: number;
    timer: number;
    score: number;
}

class MainApp extends React.Component<null, IState> {

    public state: IState = {
        lives: 3,
        timer: 4000,
        score: 0
    };

    public render(): JSX.Element {
        const { lives, timer, score } = this.state;

        return <div className="App">
            <ScoreAndLives lives={lives} score={score} />
            <ChoosedColor />
            <GridTable />
        </div >;
    }
}

export default MainApp;
