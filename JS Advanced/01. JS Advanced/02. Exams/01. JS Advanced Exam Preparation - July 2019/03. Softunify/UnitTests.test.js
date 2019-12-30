const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

const SoftUniFy = require('./03. Softunify_Ресурси.js');

describe("Test", function () {
    let softUni;

    beforeEach(function () {
        softUni = new SoftUniFy();
    });

    describe('Test Constructor', () => {
        it('Test allSongs property', () => {
            expect(softUni.allSongs).to.deep.equal({});
        });
    });

    describe('Test downloadSong()', () => {
        it('Add song to not existing Artist', () => {
            const result = softUni.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');

            expect(result).to.deep.equal({
                allSongs: {
                    Eminem: {
                        rate: 0,
                        votes: 0,
                        songs: ['Venom - Knock, Knock let the devil in...']
                    }
                }
            });
        });

        it('Add song to existing Artist', () => {
            softUni.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            const result = softUni.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');

            expect(result).to.deep.equal({
                allSongs: {
                    Eminem: {
                        rate: 0,
                        votes: 0,
                        songs: ['Venom - Knock, Knock let the devil in...', 'Phenomenal - IM PHENOMENAL...']
                    }
                }
            });
        });
    });

    describe('Test playSong()', () => {
        it('Play not downloaded song', () => {
            const result = softUni.playSong('Venom');

            expect(result).to.equal(
                `You have not downloaded a Venom song yet. Use SoftUniFy's function downloadSong() to change that!`);
        });

        it('Play downloaded song', () => {
            softUni.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            const result = softUni.playSong('Venom');

            expect(result).to.equal('Eminem:\nVenom - Knock, Knock let the devil in...\n');
        });
    });

    describe('Test songsList', () => {
        it('Return empty list', () => {
            const result = softUni.songsList;

            expect(result).to.equal('Your song list is empty');
        });

        it('Return none empty list', () => {
            softUni.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            softUni.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            const result = softUni.songsList;

            expect(result).to.equal('Venom - Knock, Knock let the devil in...\nPhenomenal - IM PHENOMENAL...');
        });
    });

    describe('Test rateArtist()', () => {
        it('Test none existing artist', () => {
            const result = softUni.rateArtist('Eminem', 50);

            expect(result).to.equal('The Eminem is not on your artist list.');
        });

        it('Test existing artist', () => {
            softUni.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            const result = softUni.rateArtist('Eminem', 50);

            expect(result).to.equal(50);
        });
    });
});