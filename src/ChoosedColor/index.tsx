import * as React from 'react'
import { Tag } from 'antd'
import ColorService from '../GridTable/ColorService';

const colorService = new ColorService();

interface IState {
    color: string;
}

class ChoosedColor extends React.Component<null, IState> {

    state: IState = {
        color: colorService.getRandomColor()
    }

    render(): JSX.Element {
        const { color } = this.state;

        return <Tag color={color}>
            <h2>Cor Escolhida</h2>
        </Tag>
    }
}

export default ChoosedColor;
