import * as React from 'react'
import { Spin } from 'antd'
import ColorService from '../GridTable/ColorService';

const colorService = new ColorService();

interface IProps {
    lives: number
}

class Lives extends React.Component<IProps> {
    render(): JSX.Element {
        const { lives } = this.props;

        return <div>
            <h1>Lives: </h1>
            {
                colorService
                    .generateArray(lives)
                    .map((_, index) => <Spin key={index} />)
            }
        </div>
    }
}

export default Lives;
