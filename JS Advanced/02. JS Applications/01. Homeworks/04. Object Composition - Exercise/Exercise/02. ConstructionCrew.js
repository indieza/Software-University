function solve(obj) {
    if (obj.dizziness === true) {
        obj.levelOfHydrated += 0.1 * obj.experience * obj.weight;
        obj.dizziness = false;
    }

    return obj;
}