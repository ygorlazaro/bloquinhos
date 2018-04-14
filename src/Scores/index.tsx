import * as React from 'react';
import { Alert } from 'antd'

interface IProps {
    score: number;
}

class Scores extends React.Component<IProps>{

    render(): JSX.Element {
        const { score } = this.props;

        return <Alert
            message={"Score: " + score}
            type="success"
        />
    }
}

export default Scores;