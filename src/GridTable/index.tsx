import * as React from 'react'
import { Card } from 'antd';
import ColorService from './ColorService';

const colorService = new ColorService();

interface IProps {

}

interface IState {
    total: number,
    items: string[]
}

const gridStyle = {
    width: '12.5%'
};

const totalBlocks: number = 64;
class GridTable extends React.Component<IProps, IState> {

    constructor(props: IProps) {
        super(props);

        this.cardGridClicked = this.cardGridClicked.bind(this);
    }

    cardGridClicked(cardClicked: number): void {
        const { items } = this.state;
        items[cardClicked] = "black";

        this.setState({
            items
        });
    }

    state: IState = {
        total: totalBlocks,
        items: colorService.generateGrid(totalBlocks)
    }

    public render(): JSX.Element {
        const { items } = this.state;

        return <div>
            <Card title="Board">
                {items.map((color, index) => {
                    return <div key={index} onClick={() => this.cardGridClicked(index)}>
                        <Card.Grid style={{ ...gridStyle, backgroundColor: color }} />
                    </div>
                }
                )}
            </Card>
        </div>
    }
}

export default GridTable;
