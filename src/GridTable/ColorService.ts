class ColorService {
    public colors = ['black', 'red', 'blue', 'green', 'yellow'];

    constructor() {
        this.generateArray = this.generateArray.bind(this);
        this.getRandomColor = this.getRandomColor.bind(this);
        this.generateGrid = this.generateGrid.bind(this);
    }

    generateArray(length: number): number[] {
        return Array.apply(null, {
            length
        }).map((_, index) => index);
    }

    getRandomColor(): string {
        const random = Math.ceil(Math.random() * 4)

        return this.colors[random];
    }

    generateGrid(totalBlocks: number) {
        return this.generateArray(totalBlocks)
            .map(this.getRandomColor);
    }
}

export default ColorService;