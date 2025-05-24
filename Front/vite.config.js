export default {
  server: {
    proxy: {
      '/api': 'https://localhost:5001',
      '/hub': {
        target: 'https://localhost:5001',
        ws: true
      }
    }
  }
}