class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
        this.totalRam = 0;
        this.totalCpu = 0;
    }

    installAProgram(name, requiredSpace) {
        if (requiredSpace > this.hddMemory) {
            throw new Error("There is not enough space on the hard drive");
        }

        let program = {
            name: name,
            requiredSpace: Number(requiredSpace)
        };

        this.hddMemory -= Number(requiredSpace);
        this.installedPrograms.push(program);

        return program;
    }

    uninstallAProgram(name) {
        const index = this.installedPrograms.findIndex(x => x.name === name);

        if (index === -1) {
            throw new Error("Control panel is not responding");
        }

        const memory = this.installedPrograms.find(x => x.name === name).requiredSpace;
        this.hddMemory += memory;
        this.installedPrograms.splice(index, 1);

        return this.installedPrograms;
    }

    openAProgram(name) {
        if (!this.installedPrograms.find(x => x.name === name)) {
            throw new Error(`The ${name} is not recognized`);
        }

        if (this.taskManager.find(x => x.name === name)) {
            throw new Error(`The ${name} is already open`);
        }

        const programs = this.installedPrograms.filter(x => x.name === name);
        let ram;
        let cpu;

        if (programs.length === 1) {
            ram = (programs[0].requiredSpace / this.ramMemory) * 1.5;
            cpu = ((programs[0].requiredSpace / this.cpuGHz) / 500) * 1.5;
        } else {
            ram = (programs.reduce((a, b) => a.requiredSpace + b.requiredSpace) / this.ramMemory) * 1.5;
            cpu = ((programs.reduce((a, b) => a.requiredSpace + b.requiredSpace) / this.cpuGHz) / 500) * 1.5;
        }

        this.totalRam += ram;
        this.totalCpu += cpu;

        if (this.totalRam >= 100) {
            throw new Error(`${name} caused out of memory exception`);
        }

        if (this.totalCpu >= 100) {
            throw new Error(`${name} caused out of cpu exception`);
        }

        let usage = {
            name: name,
            ramUsage: ram,
            cpuUsage: cpu
        };

        this.taskManager.push(usage);

        return usage;
    }
    taskManagerView() {
        if (this.taskManager.length === 0) {
            return "All running smooth so far";
        }

        return this.taskManager.
        map(x =>
                `Name - ${x.name} | Usage - CPU: ${x.cpuUsage.toFixed(0)}%, RAM: ${x.ramUsage.toFixed(0)}%`)
            .join("\n");
    }
}